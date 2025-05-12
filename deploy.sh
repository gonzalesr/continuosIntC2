cd /var/www/continuosIntC2/
git pull
dotnet restore
dotnet ef database update --project PatientManagement.Infrastructure --startup-project PatientManagement.WebApi --context StoredDbContex
dotnet build
dotnet publish --configuration Release