﻿FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
COPY ["source/SensorService/SensorService.Web/SensorService.Web.csproj", "source/SensorService/SensorService.Web/SensorService.Web.csproj"]

COPY . .
WORKDIR /source/SensorService/SensorService.Web
RUN dotnet restore "./SensorService.Web.csproj"
RUN dotnet build "./SensorService.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./SensorService.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SensorService.Web.dll"]
