# Restore, Build, Publish Project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["Ollama.AppHost/*.csproj", "Ollama.AppHost/"]
RUN dotnet restore "Ollama.AppHost/Ollama.AppHost.csproj"
COPY . .
RUN dotnet build "Ollama.AppHost/Ollama.AppHost.csproj" -c Release
#RUN dotnet publish "Ollama.AppHost/Ollama.AppHost.csproj" -c Release --os linux --arch x64 -p:PublishProfile=DefaultContainer -o /src/publish

# Create Image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /src/Ollama.AppHost/bin/Release/net9.0 .
COPY --from=build /src /src
ENV ASPNETCORE_URLS=http://+:80
WORKDIR /src
ENTRYPOINT ["dotnet", "/app/Ollama.AppHost.dll"]