FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CookingService.csproj", "CookingService/"]
RUN dotnet restore "CookingService/CookingService.csproj"
WORKDIR "/src/CookingService"
COPY . .
RUN dotnet build "CookingService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CookingService.csproj" -c Release -o /app/publish

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "CookingService.dll" ]




