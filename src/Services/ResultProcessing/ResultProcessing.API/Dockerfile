#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Services/ResultProcessing/ResultProcessing.API/ResultProcessing.API.csproj", "src/Services/ResultProcessing/ResultProcessing.API/"]

RUN dotnet restore "src/Services/ResultProcessing/ResultProcessing.API/ResultProcessing.API.csproj"

COPY . .
WORKDIR "/src/src/Services/ResultProcessing/ResultProcessing.API"
RUN dotnet build "ResultProcessing.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ResultProcessing.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ResultProcessing.API.dll"]
