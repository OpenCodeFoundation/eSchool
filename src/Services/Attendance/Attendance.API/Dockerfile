FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src

COPY "eSchool.sln" "eSchool.sln"

COPY "src/ApiGateways/eSchool.GraphQL/eSchool.GraphQL.csproj" "src/ApiGateways/eSchool.GraphQL/eSchool.GraphQL.csproj"

COPY "src/Services/Attending/Attending.API/Attending.API.csproj" "src/Services/Attending/Attending.API/Attending.API.csproj"
COPY "src/Services/Attending/Attending.Domain/Attending.Domain.csproj" "src/Services/Attending/Attending.Domain/Attending.Domain.csproj"
COPY "src/Services/Attending/Attending.Infrastructure/Attending.Infrastructure.csproj" "src/Services/Attending/Attending.Infrastructure/Attending.Infrastructure.csproj"
COPY "src/Services/Attending/Attending.UnitTests/Attending.UnitTests.csproj" "src/Services/Attending/Attending.UnitTests/Attending.UnitTests.csproj"
COPY "src/Services/Attending/Attending.FunctionalTests/Attending.FunctionalTests.csproj" "src/Services/Attending/Attending.FunctionalTests/Attending.FunctionalTests.csproj"

COPY "src/Libraries/OpenTelemetry/OpenTelemetry.csproj" "src/Libraries/OpenTelemetry/OpenTelemetry.csproj"

COPY "src/Web/WebStatus/WebStatus.csproj" "src/Web/WebStatus/WebStatus.csproj"

COPY "src/Web/Frontend.Blazor/Frontend.Blazor.Server/Frontend.Blazor.Server.csproj" "src/Web/Frontend.Blazor/Frontend.Blazor.Server/Frontend.Blazor.Server.csproj"
COPY "src/Web/Frontend.Blazor/Frontend.Blazor.Client/Frontend.Blazor.Client.csproj" "src/Web/Frontend.Blazor/Frontend.Blazor.Client/Frontend.Blazor.Client.csproj"
COPY "src/Web/Frontend.Blazor/Frontend.Blazor.Shared/Frontend.Blazor.Shared.csproj" "src/Web/Frontend.Blazor/Frontend.Blazor.Shared/Frontend.Blazor.Shared.csproj"

COPY "docker-compose.dcproj" "docker-compose.dcproj"

RUN dotnet restore eSchool.sln -nowarn:msb3202,nu1503

COPY . .
WORKDIR /src/src/Services/Attending/Attending.API
RUN dotnet build --no-restore -c Release -o /app/build

FROM build as unittest
WORKDIR /src/src/Services/Attending/Attending.UnitTests

FROM build as functionaltest
WORKDIR /src/src/Services/Attending/Attending.FunctionalTests

FROM build AS publish
RUN dotnet publish --no-restore -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Attending.API.dll"]