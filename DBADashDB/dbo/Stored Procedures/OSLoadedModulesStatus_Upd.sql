﻿CREATE PROC OSLoadedModulesStatus_Upd
AS	
UPDATE M 
	SET M.Status= ISNULL(s.Status,2)
FROM dbo.OSLoadedModules M
OUTER APPLY(SELECT MIN(MS.Status) Status 
				FROM dbo.OSLoadedModulesStatus MS 
				WHERE ISNULL(M.company,'') LIKE MS.Company 
				AND ISNULL(M.name,'') LIKE MS.Name 
				AND ISNULL(M.description,'') LIKE MS.Description ) s