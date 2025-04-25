FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["fumble_funds.csproj", "./"]
RUN dotnet restore "./fumble_funds.csproj"
COPY . .
RUN dotnet publish "fumble_funds.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "fumble_funds.dll"]
