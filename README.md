# acdemic_serv

dotnet ef migrations add InitialMigration --project infrastructure/infrastructure.csproj --startup-project acdemic_serv/acdemic_serv.csproj

dotnet ef database update --project infrastructure --startup-project acdemic_serv
