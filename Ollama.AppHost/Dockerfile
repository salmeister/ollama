# Restore, Build, Publish Project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app
COPY **/*.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet publish /app/*.csproj -c Release -o /app/publish

# Create Image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Ollama.AppHost.dll"]