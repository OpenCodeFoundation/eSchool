#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

COPY ["src/ApiGateways/eSchool.GraphQL/eSchool.GraphQL.csproj", "src/ApiGateways/eSchool.GraphQL/"]
COPY ["src/Libraries/OpenTelemetry/OpenTelemetry.csproj", "src/Libraries/OpenTelemetry/"]

RUN dotnet restore "src/ApiGateways/eSchool.GraphQL/eSchool.GraphQL.csproj"

COPY . .
WORKDIR "/src/src/ApiGateways/eSchool.GraphQL"
RUN dotnet build "eSchool.GraphQL.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "eSchool.GraphQL.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ESchool.GraphQL.dll"]