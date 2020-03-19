﻿CREATE TABLE [dbo].[ProcStats_60MIN] (
    [InstanceID]           INT           NOT NULL,
    [ProcID]               INT           NOT NULL,
    [SnapshotDate]         DATETIME2 (3) NOT NULL,
    [PeriodTime]           BIGINT        NOT NULL,
    [total_worker_time]    BIGINT        NOT NULL,
    [total_elapsed_time]   BIGINT        NOT NULL,
    [total_logical_reads]  BIGINT        NOT NULL,
    [total_logical_writes] BIGINT        NOT NULL,
    [total_physical_reads] BIGINT        NOT NULL,
    [execution_count]      BIGINT        NOT NULL,
    [IsCompile]            BIT           NOT NULL,
    CONSTRAINT [PK_ProcStats_60MIN] PRIMARY KEY CLUSTERED ([InstanceID] ASC, [SnapshotDate] ASC, [ProcID] ASC) WITH (DATA_COMPRESSION = PAGE),
    CONSTRAINT [FK_ProcStats_60MIN_Procs] FOREIGN KEY ([ProcID]) REFERENCES [dbo].[Procs] ([ProcID])
);

