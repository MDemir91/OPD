# Build aşaması
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["OPD.csproj", "."]
RUN dotnet restore "OPD.csproj"
COPY . .
RUN dotnet build "OPD.csproj" -c $BUILD_CONFIGURATION -o /app/build
RUN dotnet publish "OPD.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Runtime aşaması
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "OPD.dll"]
