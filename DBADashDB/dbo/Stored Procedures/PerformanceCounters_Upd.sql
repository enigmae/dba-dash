﻿CREATE   PROC dbo.PerformanceCounters_Upd(
	@InstanceID INT,
	@SnapshotDate DATETIME2(7),
	@PerformanceCounters dbo.PerformanceCounters READONLY,
	@Internal BIT=0
)
AS
SET XACT_ABORT ON
DECLARE @Ref NVARCHAR(128)='PerformanceCounters'

INSERT INTO dbo.Counters
(
    object_name,
    counter_name,
    instance_name
)
SELECT RTRIM(object_name),RTRIM(counter_name),RTRIM(instance_name) 
FROM @PerformanceCounters
WHERE cntr_type NOT IN(1073874176,537003264,1073939712)
EXCEPT 
SELECT object_name,counter_name,instance_name 
FROM dbo.Counters WITH(UPDLOCK);

INSERT INTO dbo.InstanceCounters(InstanceID,CounterID)
SELECT @InstanceID,C.CounterID
FROM @PerformanceCounters pc 
JOIN dbo.Counters C ON C.counter_name = pc.counter_name AND C.instance_name = pc.instance_name AND C.object_name = pc.object_name
EXCEPT 
SELECT InstanceID,CounterID 
FROM dbo.InstanceCounters
WHERE InstanceID =@InstanceID;

UPDATE IC 
SET IC.UpdatedDate = @SnapshotDate
FROM dbo.InstanceCounters IC 
WHERE InstanceID = @InstanceID
AND EXISTS(SELECT 1 
		FROM @PerformanceCounters pc 
		JOIN dbo.Counters C ON C.counter_name = pc.counter_name AND C.instance_name = pc.instance_name AND C.object_name = pc.object_name
		WHERE C.CounterID= IC.CounterID
		AND pc.cntr_type NOT IN(1073874176,537003264,1073939712)
		)

DECLARE @PC TABLE(
[InstanceID] [int] NOT NULL,
[CounterID] [int] NOT NULL,
[SnapshotDate] [datetime2] (2) NOT NULL,
[SnapshotDate60] [datetime2] (2) NOT NULL,
[Value] [decimal] (28, 9) NULL,
PRIMARY KEY(InstanceID,CounterID,SnapshotDate)
) 

INSERT INTO @PC
(
    InstanceID,
    CounterID,
    SnapshotDate,
	SnapshotDate60,
    Value
)
SELECT @InstanceID AS InstanceID,
	C.CounterID,
	B.SnapshotDate,
	DG.DateGroup,
	CASE WHEN B.cntr_type = 65792 AND B.object_name='Batch Resp Statistics' AND B.cntr_value >= A.cntr_value THEN B.cntr_value - A.cntr_value
		WHEN B.cntr_type = 65792 AND B.object_name<>'Batch Resp Statistics' THEN B.cntr_value 
		WHEN B.cntr_type = 272696576 AND B.cntr_value>=A.cntr_value THEN (B.cntr_value-A.cntr_value) / (DATEDIFF(ms,A.SnapshotDate,B.SnapshotDate)/1000.0)
		WHEN B.cntr_type=537003264 THEN B.cntr_value*1.0 / NULLIF(Bbase.cntr_value,0)
		WHEN B.cntr_type=1073874176 AND Bbase.cntr_value>=Abase.cntr_value THEN (B.cntr_value-A.cntr_value*1.0) / NULLIF(Bbase.cntr_value-Abase.cntr_value,0)
	ELSE NULL END AS Value
FROM @PerformanceCounters B
CROSS APPLY [dbo].[DateGroupingMins](B.SnapshotDate,60) DG
JOIN dbo.Counters C ON C.counter_name = B.counter_name AND C.object_name = B.object_name AND C.instance_name = B.instance_name
LEFT JOIN dbo.CounterMapping M ON B.object_name = M.object_name 
								AND B.counter_name = M.counter_name 
								AND B.cntr_type IN(1073874176,272696576)
LEFT JOIN @PerformanceCounters Bbase ON B.object_name = M.object_name 
										AND B.counter_name = M.base_counter_name 
										AND Bbase.instance_name = B.instance_name 
										AND Bbase.cntr_type=1073939712	
										AND B.cntr_type IN(1073874176,537003264)
LEFT JOIN Staging.PerformanceCounters A ON A.object_name = b.object_name 
											AND A.counter_name = B.counter_name 
											AND A.instance_name = B.instance_name 
											AND B.cntr_type = A.cntr_type 
											AND A.InstanceID = @InstanceID
											AND A.SnapshotDate< B.SnapshotDate
LEFT JOIN Staging.PerformanceCounters Abase ON Abase.object_name = M.object_name 
											AND Abase.counter_name = M.base_counter_name 
											AND Abase.instance_name = B.instance_name 
											AND A.cntr_type = 1073874176 
											AND Abase.InstanceID = @InstanceID 
											AND Abase.cntr_type=1073939712	
											AND ABase.SnapshotDate <B.SnapshotDate
WHERE B.cntr_type IN(65792,272696576,537003264,1073874176)
AND NOT EXISTS(SELECT 1 FROM dbo.PerformanceCounters PC WHERE PC.SnapshotDate = CAST(B.SnapshotDate as DATETIME2(2)) AND PC.InstanceID = @InstanceID AND PC.CounterID=C.CounterID)
AND (DATEDIFF(mi,A.SnapshotDate,B.SnapshotDate)< 1440 OR A.SnapshotDate IS NULL)

BEGIN TRAN
INSERT INTO dbo.PerformanceCounters
(
    InstanceID,
    CounterID,
    SnapshotDate,
    Value
)
SELECT PC.InstanceID,
       PC.CounterID,
	   PC.SnapshotDate,
       PC.Value	
FROM @PC PC
WHERE Value IS NOT NULL;

WITH T AS (
	SELECT PC.InstanceID,
		PC.CounterID,
		PC.SnapshotDate60,
		SUM(PC.Value) as Value_Total,
		MIN(PC.Value) as Value_Min,
		MAX(PC.Value) as Value_Max,
		COUNT(*) as SampleCount  
	FROM @PC PC
	WHERE PC.Value IS NOT NULL
	GROUP BY PC.InstanceID,
		PC.CounterID,
		PC.SnapshotDate60
)
UPDATE PC60
	SET PC60.Value_Total += T.Value_Total,
	PC60.Value_Min = CASE WHEN T.Value_Min < PC60.Value_Min THEN T.Value_Min ELSE PC60.Value_Min END,
	PC60.Value_Max = CASE WHEN T.Value_Max > PC60.Value_Max THEN T.Value_Max ELSE PC60.Value_Max END,
	PC60.SampleCount+=T.SampleCount
FROM dbo.PerformanceCounters_60MIN PC60
JOIN T ON T.InstanceID = PC60.InstanceID AND T.CounterID = PC60.CounterID AND T.SnapshotDate60 = PC60.SnapshotDate

INSERT INTO dbo.PerformanceCounters_60MIN
(
    InstanceID,
    CounterID,
    SnapshotDate,
    Value_Total,
    Value_Min,
    Value_Max,
    SampleCount
)
SELECT PC.InstanceID,
		PC.CounterID,
		PC.SnapshotDate60,
		SUM(PC.Value),
		MIN(PC.Value),
		MAX(PC.Value),
		COUNT(*)  
FROM @PC PC
WHERE Value IS NOT NULL
AND NOT EXISTS(SELECT 1 FROM dbo.PerformanceCounters_60MIN PC60 WHERE PC60.InstanceID = PC.InstanceID AND PC60.CounterID = PC.CounterID AND PC60.SnapshotDate = PC.SnapshotDate60)
GROUP BY PC.InstanceID,
		PC.CounterID,
		PC.SnapshotDate60

IF @Internal=0
BEGIN
	DELETE Staging.PerformanceCounters WHERE InstanceID = @InstanceID
	INSERT INTO Staging.PerformanceCounters(
		   InstanceID,
		   SnapshotDate,
		   object_name,
		   counter_name,
		   instance_name,
		   cntr_value,
		   cntr_type
		   )
	SELECT @InstanceID,
		   SnapshotDate,
		   object_name,
		   counter_name,
		   instance_name,
		   cntr_value,
		   cntr_type
	FROM @PerformanceCounters
	WHERE (cntr_type <> 65792 OR object_name='Batch Resp Statistics')
END

COMMIT
IF @Internal=0
BEGIN
	EXEC dbo.CollectionDates_Upd @InstanceID = @InstanceID,
								 @Reference = @Ref,
								 @SnapshotDate = @SnapshotDate
END