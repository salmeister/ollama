# Use the official .NET 9 ASP.NET image as the base image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

# Use the official .NET 9 SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /src
COPY [".", "."]
RUN dotnet build "Ollama.AppHost.csproj" -c Release -o /app/build
RUN dotnet build "Ollama.AppHost.csproj" -c Release -o /app/build


FROM build AS publish
RUN dotnet publish "Ollama.AppHost.csproj" -c Release -o /app/publish

# Copy the build and publish output to the base image and set the entry point
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ollama.AppHost.dll"]