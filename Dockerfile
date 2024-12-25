# используемый образ + установленная платформа .NET
FROM mcr.microsoft.com/dotnet/aspnet:8.0 as base

EXPOSE 80
ENV ASPNETCORE_URLS http://+:80
ENV ASPNETCORE_ENVIRONMENT Development

WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
WORKDIR /src

COPY ["BackendApi/BackendApi.csproj", "BackendApi/"]
COPY ["BusinessLogic/BusinessLogic.csproj", "BusinessLogic/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["DataAccess/DataAccess.csproj", "DataAccess/"]
RUN dotnet restore "BackendApi/BackendApi.csproj"

COPY . .
FROM build as publish
RUN dotnet publish "BackendApi/BackendApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base as final
WORKDIR /app

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BackendApi.dll"]