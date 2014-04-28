REM --------------------------------------------------------------------------
REM This batch install Service Stack
REM 
REM Get Nuget here:
REM http://nuget.org/nuget.exe
REM --------------------------------------------------------------------------
IF NOT EXIST packages mkdir packages
cd packages

..\nuget.exe install ServiceStack.Text -Version 3.9.71.0
..\nuget.exe install ServiceStack.Common -Version 3.9.71.0
..\nuget.exe install ServiceStack -Version 3.9.71.0
..\nuget.exe install ServiceStack.OrmLite.SqlServer -Version 3.9.71.0
..\nuget.exe install ServiceStack.OrmLite.MySql -Version 3.9.71.0
..\nuget.exe install MySql.Data -Version 6.6.4.0
..\nuget.exe install System.Data.SQLite -Version 1.0.92.0
..\nuget.exe install Quartz -Version 2.2.3