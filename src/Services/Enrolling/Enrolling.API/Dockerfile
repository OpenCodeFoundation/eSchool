#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["src/Services/Enrolling/Enrolling.API/Enrolling.API.csproj", "src/Services/Enrolling/Enrolling.API/"]
COPY ["src/Services/Enrolling/Enrolling.Infrastructure/Enrolling.Infrastructure.csproj", "src/Services/Enrolling/Enrolling.Infrastructure/"]
COPY ["src/Services/Enrolling/Enrolling.Domain/Enrolling.Domain.csproj", "src/Services/Enrolling/Enrolling.Domain/"]

COPY ["src/Libraries/OpenTelemetry/OpenTelemetry.csproj", "src/Libraries/OpenTelemetry/"]

RUN dotnet restore "src/Services/Enrolling/Enrolling.API/Enrolling.API.csproj"

COPY . .
WORKDIR "/src/src/Services/Enrolling/Enrolling.API"
RUN dotnet build "Enrolling.API.csproj" -c Release -o /app/build

FROM build as unittest
WORKDIR /src/src/Services/Enrolling/Enrolling.UnitTests

FROM build as functionaltest
WORKDIR /src/src/Services/Enrolling/Enrolling.FunctionalTests

FROM build AS publish
RUN dotnet publish "Enrolling.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Enrolling.API.dll"]