﻿CLI
Migration:
dotnet ef migrations add InitialCreate --output-dir Data/Migrations --project CarManagementApp.Infrastructure --startup-project CarManagementApp.Api
Update DB
dotnet ef database update --project CarManagementApp.Infrastructure --startup-project CarManagementApp.Api

Package Manager Console
Add-Migration InitialCreate
Update-Database