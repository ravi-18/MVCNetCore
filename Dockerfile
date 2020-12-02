# STAGE01 - Build application and its dependencies
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS build-env
WORKDIR /app
COPY ./src/LandingPage/*.csproj ./
COPY . ./
RUN dotnet restore 

# STAGE02 - Publish the application
FROM build-env AS publish
RUN dotnet publish -c Release -o /app

# STAGE03 - Create the final image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-aspnetcore-runtime
WORKDIR /app
LABEL Author="Gaurav Gahlot"
LABEL Maintainer="quickdevnotes"
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebApp.dll", "--server.urls", "http://*:80"]