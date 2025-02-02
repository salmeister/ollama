# Restore, Build, Publish Project
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
COPY **/*.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet publish -c Release -o out

# Create Image
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app
COPY --from=build /app/out 
ENTRYPOINT ["dotnet", "Ollama.AppHost.dll"]