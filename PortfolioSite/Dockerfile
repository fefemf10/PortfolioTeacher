FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PortfolioSite/PortfolioSite.csproj", "PortfolioSite/"]
COPY ["Portfolio.Application/Portfolio.Application.csproj", "Portfolio.Application/"]
RUN dotnet restore "./PortfolioSite/PortfolioSite.csproj"
COPY . .
WORKDIR "/src/PortfolioSite"
RUN dotnet publish "./PortfolioSite.csproj" -c $BUILD_CONFIGURATION -o output
# Use an Nginx base image
FROM nginx:alpine
WORKDIR /var/www/web
# Copy the Nginx configuration
COPY --from=build /app/output/wwwroot .
# Copy the Blazor WebAssembly app files
COPY --from=build nginx.conf /etc/nginx/conf.d/default.conf

# Expose port 4000
EXPOSE 4000
# Start Nginx
CMD ["nginx", "-g", "daemon off;"]
