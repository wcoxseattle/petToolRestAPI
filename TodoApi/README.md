# PetToolAPI


## Getting Started
WIP


## Development
### Database Migrations
Migrations must be triggered for initial database creation and each subsequent 
update. Database migrations are handled using EntityFramework's CLI tools (
Microsoft.EntityFrameworkCore.Tools).

The CLI tool can be made available using the following command:
```
dotnet tool install --global dotnet-ef
```

To start a migration execute the following:
```
# Adds a migration file to the `Migrations` directory
dotnet ef migrations add <name_of_migration>
# Updates physical database with migration
dotnet ef database update
```

### Swagger Documentation
Hosted at localhost/swagger