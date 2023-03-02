FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 90

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CheeseService.csproj", "CheeseService/"]
RUN dotnet restore "CheeseService/CheeseService.csproj"
WORKDIR "/src/CheeseService"
COPY . .
RUN dotnet build "CheeseService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CheeseService.csproj" -c Release -o /app/publish

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "CheeseService.dll" ]