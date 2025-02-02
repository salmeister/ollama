# Restore, Build, Publish Project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY **/*.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet build "Ollama.AppHost.csproj" -c Release
#RUN dotnet publish "Ollama.AppHost/Ollama.AppHost.csproj" -c Release --os linux --arch x64 -p:PublishProfile=DefaultContainer -o /src/publish

# Create Image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /src/Ollama.AppHost/bin/Release/net9.0 .
ENTRYPOINT ["dotnet", "./Ollama.AppHost.dll"]