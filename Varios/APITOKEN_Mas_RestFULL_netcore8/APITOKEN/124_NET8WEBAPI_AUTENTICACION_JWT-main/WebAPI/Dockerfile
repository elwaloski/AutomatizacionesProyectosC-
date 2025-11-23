# ===== Etapa de build =====
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar solución y csproj
COPY *.sln ./
COPY WebAPI/*.csproj WebAPI/

# Restaurar dependencias
RUN dotnet restore

# Copiar todo el código
COPY . .

# Publicar en modo Release
RUN dotnet publish WebAPI/Token.csproj -c Release -o /app/publish


# ===== Etapa final =====
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "Token.dll"]
