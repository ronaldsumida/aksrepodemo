# Sample Dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WebAPIDemo/WebAPIDemo.csproj", "WebAPIDemo/"]
COPY ["IRepositoryLib/IRepositoryLib.csproj", "IRepositoryLib/"]
COPY ["LoggerLib/LoggerLib.csproj", "LoggerLib/"]
COPY ["ProductLib/ProductLib.csproj", "ProductLib/"]
COPY ["ProductRepoLib/ProductRepoLib.csproj", "ProductRepoLib/"]
RUN dotnet restore "WebAPIDemo/WebAPIDemo.csproj"

# Sample Dockerfile continued
COPY . .
WORKDIR "/src/WebAPIDemo"
RUN dotnet build "WebAPIDemo.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "WebAPIDemo.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAPIDemo.dll"]
