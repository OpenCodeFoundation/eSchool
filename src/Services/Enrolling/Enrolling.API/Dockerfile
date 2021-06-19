FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src

COPY "eSchool.sln" "eSchool.sln"

COPY "src/ApiGateways/eSchool.GraphQL/eSchool.GraphQL.csproj" "src/ApiGateways/eSchool.GraphQL/eSchool.GraphQL.csproj"

COPY "src/Services/Enrolling/Enrolling.API/Enrolling.API.csproj" "src/Services/Enrolling/Enrolling.API/Enrolling.API.csproj"
COPY "src/Services/Enrolling/Enrolling.Domain/Enrolling.Domain.csproj" "src/Services/Enrolling/Enrolling.Domain/Enrolling.Domain.csproj"
COPY "src/Services/Enrolling/Enrolling.Infrastructure/Enrolling.Infrastructure.csproj" "src/Services/Enrolling/Enrolling.Infrastructure/Enrolling.Infrastructure.csproj"
COPY "src/Services/Enrolling/Enrolling.UnitTests/Enrolling.UnitTests.csproj" "src/Services/Enrolling/Enrolling.UnitTests/Enrolling.UnitTests.csproj"
COPY "src/Services/Enrolling/Enrolling.FunctionalTests/Enrolling.FunctionalTests.csproj" "src/Services/Enrolling/Enrolling.FunctionalTests/Enrolling.FunctionalTests.csproj"

COPY "src/Services/CertificateProcessing/CertificateProcessing.API/CertificateProcessing.API.csproj" "src/Services/CertificateProcessing/CertificateProcessing.API/CertificateProcessing.API.csproj"

COPY "src/Libraries/OpenTelemetry/OpenTelemetry.csproj" "src/Libraries/OpenTelemetry/OpenTelemetry.csproj"

COPY "src/Web/WebStatus/WebStatus.csproj" "src/Web/WebStatus/WebStatus.csproj"

COPY "src/Web/Frontend.Blazor/Frontend.Blazor.Server/Frontend.Blazor.Server.csproj" "src/Web/Frontend.Blazor/Frontend.Blazor.Server/Frontend.Blazor.Server.csproj"
COPY "src/Web/Frontend.Blazor/Frontend.Blazor.Client/Frontend.Blazor.Client.csproj" "src/Web/Frontend.Blazor/Frontend.Blazor.Client/Frontend.Blazor.Client.csproj"
COPY "src/Web/Frontend.Blazor/Frontend.Blazor.Shared/Frontend.Blazor.Shared.csproj" "src/Web/Frontend.Blazor/Frontend.Blazor.Shared/Frontend.Blazor.Shared.csproj"

COPY "docker-compose.dcproj" "docker-compose.dcproj"

RUN dotnet restore eSchool.sln -nowarn:msb3202,nu1503

COPY . .
WORKDIR /src/src/Services/Enrolling/Enrolling.API
RUN dotnet build --no-restore -c Release -o /app/build

FROM build as unittest
WORKDIR /src/src/Services/Enrolling/Enrolling.UnitTests

FROM build as functionaltest
WORKDIR /src/src/Services/Enrolling/Enrolling.FunctionalTests

FROM build AS publish
RUN dotnet publish --no-restore -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Enrolling.API.dll"]