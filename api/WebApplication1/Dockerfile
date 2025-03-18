# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the project files and restore dependencies
COPY *.sln .
COPY WebApplication1/*.csproj ./WebApplication1/
RUN dotnet restore WebApplication1/WebApplication1.csproj

# Copy the rest of the files and build the application
COPY WebApplication1/ . /WebApplication1/
WORKDIR /app/WebApplication1
RUN dotnet publish -c Release -o out

# Use the ASP.NET runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/NobApplicationi/out/ .
ENTRYPOINT ["dotnet", "WebApplication1.dll"]
