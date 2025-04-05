#!/bin/sh
echo "Instalando netcat..."
apt-get update && apt-get install -y netcat-openbsd

# echo "Valor de MYSQL_CONTAINER: '$MYSQL_CONTAINER'"

# if [ -z "$MYSQL_CONTAINER" ]; then
#   echo "ERROR: La variable MYSQL_CONTAINER no está definida. Revisa tu docker-compose.yml."
#   exit 1
# fi

echo "Esperando a que MySQL esté disponible..."

until nc -z "api_db" 3306; do
  echo "Esperando a MySQL..."
  sleep 2
done

echo "MySQL está disponible. Iniciando la API..."

# Ejecutar migraciones si usas Entity Framework Core
# dotnet ef database update || echo "No se ejecutaron migraciones."
dotnet tool install --global dotnet-ef --version 8.0.8
export PATH="$PATH:/root/.dotnet/tools"
dotnet build ./PatientManagement.WebApi/PatientManagement.WebApi.csproj
dotnet ef database update --project ./PatientManagement.WebApi/PatientManagement.WebApi.csproj &&


# Iniciar la aplicación
exec dotnet PatientManagement.WebApi.dll