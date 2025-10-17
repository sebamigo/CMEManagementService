dotnet ef migrations add CreateTeilnahmeJoinEntity

dotnet ef database update

# create first sql file
dotnet ef migrations script --output ../Ressources/DB/SQL/init_db.sql --idempotent

# create migration file
dotnet ef migrations script InitialCreate AddEmailToDoctor --output ./deploy/v2_add_email.sql --idempotent