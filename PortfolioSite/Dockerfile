FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /app
COPY ["PortfolioSite/PortfolioSite.csproj", "PortfolioSite/"]
COPY ["Portfolio.Infrastructure/Portfolio.Infrastructure.csproj", "Portfolio.Infrastructure/"]
COPY ["Portfolio.Domain/Portfolio.Domain.csproj", "Portfolio.Domain/"]
COPY ["Portfolio.Application/Portfolio.Application.csproj", "Portfolio.Application/"]
RUN dotnet restore "PortfolioSite/PortfolioSite.csproj"
COPY . ./
RUN dotnet publish "PortfolioSite/PortfolioSite.csproj" -c $BUILD_CONFIGURATION -o /out
# Use an Nginx base image
FROM nginx:alpine
WORKDIR /usr/share/nginx/html
# Copy the Nginx configuration
COPY --from=build /out/wwwroot .
# Copy the Blazor WebAssembly app files
COPY PortfolioSite/nginx.conf /etc/nginx/nginx.conf

# Expose port 4000
EXPOSE 4000
# Start Nginx
CMD ["nginx", "-g", "daemon off;"]
