FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src

COPY "eSchool.sln" "eSchool.sln"

COPY "src/Services/Enrolling/Enrolling.API/Enrolling.API.csproj" "src/Services/Enrolling/Enrolling.API/Enrolling.API.csproj"
COPY "src/Services/Enrolling/Enrolling.Domain/Enrolling.Domain.csproj" "src/Services/Enrolling/Enrolling.Domain/Enrolling.Domain.csproj"
COPY "src/Services/Enrolling/Enrolling.Infrastructure/Enrolling.Infrastructure.csproj" "src/Services/Enrolling/Enrolling.Infrastructure/Enrolling.Infrastructure.csproj"
COPY "src/Services/Enrolling/Enrolling.UnitTests/Enrolling.UnitTests.csproj" "src/Services/Enrolling/Enrolling.UnitTests/Enrolling.UnitTests.csproj"
COPY "src/Services/Enrolling/Enrolling.FunctionalTests/Enrolling.FunctionalTests.csproj" "src/Services/Enrolling/Enrolling.FunctionalTests/Enrolling.FunctionalTests.csproj"

COPY "src/Services/Identity/Identity.API/Identity.API.csproj" "src/Services/Identity/Identity.API/Identity.API.csproj"

COPY "src/Web/WebStatus/WebStatus.csproj" "src/Web/WebStatus/WebStatus.csproj"

COPY "docker-compose.dcproj" "docker-compose.dcproj"

RUN dotnet restore eSchool.sln -nowarn:msb3202,nu1503

COPY . .

WORKDIR /src/src/Services/Identity/Identity.API
RUN dotnet build --no-restore -c Release -o /app/build

FROM build AS publish
RUN dotnet publish --no-restore -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Identity.API.dll"]