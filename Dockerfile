FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 3000
EXPOSE 3001

# Usa la imagen base de .NET para construir el proyecto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["PatientManagement.WebApi/*.csproj", "PatientManagement.WebApi/"]
COPY ["PatientManagement.Application/*.csproj", "PatientManagement.Application/"]
COPY ["PatientManagement.Infrastructure/*.csproj", "PatientManagement.Infrastructure/"]
COPY ["Patient.Domain/*.csproj", "PatientManagement.Domain/"]

RUN dotnet restore "./PatientManagement.WebApi/PatientManagement.WebApi.csproj"

# Copia el código fuente y compila el proyecto
COPY . .
# Instalar herramientas globales de EF Core

# RUN /root/.dotnet/tools/dotnet-ef migrations add InitialCreate --project ./PatientManagement.WebApi/PatientManagement.WebApi.csproj -v
# RUN /root/.dotnet/tools/dotnet-ef database update --project ./PatientManagement.WebApi/PatientManagement.WebApi.csproj

WORKDIR "/src/PatientManagement.WebApi"
RUN dotnet tool install --global dotnet-ef --version 8.0.8
ENV PATH="$PATH:/root/.dotnet/tools"
RUN dotnet build "./PatientManagement.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish
# ENTRYPOINT dotnet ef database update --environment Development --project src/PatientManagement.WebApi
# ENTRYPOINT dotnet ef migrations add InitialCreate --environment Development --project src/PatientManagement.WebApi

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PatientManagement.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Usa una imagen más ligera para ejecutar la app
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "PatientManagement.WebApi.dll"]