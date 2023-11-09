# Code First Migrations
# 
# Note:
##  a. Startup Project = 
##  b. Default Project = HtlPortalCore.DataAccess
#
# 1. Create Migration: run following command in Package Manager Console
##    Add-Migration InitialDb -Project HtlPortalCore.DataAccess
#
# 2. Update Database:
##    Update-Database
#
# 3. Remove Migration: In case if we need to delete the Added Migration before update-database, then execute following command:
##    Remove-Migration