#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PortfolioSite/PortfolioSite.csproj", "PortfolioSite/"]
COPY ["PortfolioShared/PortfolioShared.csproj", "PortfolioShared/"]
RUN dotnet restore "./PortfolioSite/PortfolioSite.csproj"
COPY . .
WORKDIR "/src/PortfolioSite"
RUN dotnet build "./PortfolioSite.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PortfolioSite.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM nginx AS final
ARG Environment
COPY --from=publish /src/PortfolioSite/nginx.conf /etc/nginx/nginx.conf
RUN sed -i "s/replaceme/${Environment}/" /etc/nginx/nginx.conf
COPY --from=publish /app/publish/wwwroot /usr/share/nginx/html