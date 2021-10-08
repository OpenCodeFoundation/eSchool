#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

COPY ["src/Web/Frontend.Blazor/Frontend.Blazor.Server/Frontend.Blazor.Server.csproj", "src/Web/Frontend.Blazor/Frontend.Blazor.Server/"]
COPY ["src/Web/Frontend.Blazor/Frontend.Blazor.Shared/Frontend.Blazor.Shared.csproj", "src/Web/Frontend.Blazor/Frontend.Blazor.Shared/"]
COPY ["src/Web/Frontend.Blazor/Frontend.Blazor.Client/Frontend.Blazor.Client.csproj", "src/Web/Frontend.Blazor/Frontend.Blazor.Client/"]

RUN dotnet restore "src/Web/Frontend.Blazor/Frontend.Blazor.Server/Frontend.Blazor.Server.csproj"

COPY . .
WORKDIR "/src/src/Web/Frontend.Blazor/Frontend.Blazor.Server"
RUN dotnet build "Frontend.Blazor.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Frontend.Blazor.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Frontend.Blazor.Server.dll"]