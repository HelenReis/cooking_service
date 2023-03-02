FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BreadService.csproj", "BreadService/"]
RUN dotnet restore "BreadService/BreadService.csproj"
WORKDIR "/src/BreadService"
COPY . .
RUN dotnet build "BreadService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BreadService.csproj" -c Release -o /app/publish

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "BreadService.dll" ]




