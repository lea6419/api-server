# Use the official .NET SDK image as a parent image.
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WebApplication1.sln", "."]
COPY ["WebApplication1/WebApplication1.csproj", "WebApplication1/"]
COPY ["Core/Data/Core.Data.csproj", "Core/Data/"]
COPY ["Core/Service/Core.Service.csproj", "Core/Service/"]
COPY ["Core/DTO/Core.DTO.csproj", "Core/DTO/"] # הוספת פרויקט DTO
COPY ["Core/Interface/Core.Interface.csproj", "Core/Interface/"] # הוספת פרויקט Interface
COPY ["Core/Models/Core.Models.csproj", "Core/Models/"] # הוספת פרויקט Models
RUN dotnet restore "WebApplication1/WebApplication1.csproj"
RUN dotnet restore "Core/Data/Core.Data.csproj"
RUN dotnet restore "Core/Service/Core.Service.csproj"
RUN dotnet restore "Core/DTO/Core.DTO.csproj" # הוספת restore עבור DTO
RUN dotnet restore "Core/Interface/Core.Interface.csproj" # הוספת restore עבור Interface
RUN dotnet restore "Core/Models/Core.Models.csproj" # הוספת restore עבור Models
COPY . .
WORKDIR "/src/WebApplication1"
RUN dotnet build "WebApplication1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApplication1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApplication1.dll"]
