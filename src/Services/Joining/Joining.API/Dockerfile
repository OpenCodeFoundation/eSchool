#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src

COPY ["src/Services/Joining/Joining.API/Joining.API.csproj", "src/Services/Joining/Joining.API/"]
COPY ["src/Services/Joining/Joining.Domain/Joining.Domain.csproj", "src/Services/Joining/Joining.Domain/"]
COPY ["src/Services/Joining/Joining.Infrastructure/Joining.Infrastructure.csproj", "src/Services/Joining/Joining.Infrastructure/"]
COPY ["src/Services/Joining/Joining.UnitTests/Joining.UnitTests.csproj", "src/Services/Joining/Joining.UnitTests/"]
COPY ["src/Services/Joining/Joining.FunctionalTests/Joining.FunctionalTests.csproj", "src/Services/Joining/Joining.FunctionalTests/"]

RUN dotnet restore "src/Services/Joining/Joining.API/Joining.API.csproj"
RUN dotnet restore "src/Services/Joining/Joining.UnitTests/Joining.UnitTests.csproj"
RUN dotnet restore "src/Services/Joining/Joining.FunctionalTests/Joining.FunctionalTests.csproj"

COPY . .
WORKDIR "/src/src/Services/Joining/Joining.API"
RUN dotnet build "Joining.API.csproj" -c Release -o /app/build

FROM build as unittest
WORKDIR /src/src/Services/Joining/Joining.UnitTests

FROM build as functionaltest
WORKDIR /src/src/Services/Joining/Joining.FunctionalTests

FROM build AS publish
RUN dotnet publish "Joining.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Joining.API.dll"]