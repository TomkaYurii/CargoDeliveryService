FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ["CargoOrderingService/src/CargoOrderingService/CargoOrderingService.csproj", "./CargoOrderingService/src/CargoOrderingService/"]
COPY ["SharedKernel/SharedKernel.csproj", "./SharedKernel/"]
RUN dotnet restore "./CargoOrderingService/src/CargoOrderingService/CargoOrderingService.csproj"

# Copy everything else and build
COPY . ./
RUN dotnet build "CargoOrderingService/src/CargoOrderingService/CargoOrderingService.csproj" -c Release -o /app/build

FROM build-env AS publish
RUN dotnet publish "CargoOrderingService/src/CargoOrderingService/CargoOrderingService.csproj" -c Release -o /app/out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=publish /app/out .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "/app/CargoOrderingService.dll"]
