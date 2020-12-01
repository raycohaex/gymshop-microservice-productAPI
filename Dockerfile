FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY GymShopAPI.sln ./
COPY GymShopAPI.BBL/*.csproj ./GymShopAPI.BBL/
COPY GymShopAPI.DAL/*.csproj ./GymShopAPI.DAL/

RUN dotnet restore GymShopAPI.BBL

# Copy everything else and build
COPY GymShopAPI.BBL/. ./GymShopAPI.BBL/
COPY GymShopAPI.DAL/. ./GymShopAPI.DAL/

RUN dotnet publish -c Release -o out GymShopAPI.BBL

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/sdk:3.1
ENV ASPNETCORE_URLS=http://+:5000
ENV ASPNETCORE_URLS=https://+:5001
EXPOSE 5000 5001 $port
WORKDIR /app
COPY --from=build-env /app/out .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet GymShopAPI.BBL.dll