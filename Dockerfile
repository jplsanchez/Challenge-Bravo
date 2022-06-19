#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CB.API/CB.API.csproj", "CB.API/"]
RUN dotnet restore "CB.API/CB.API.csproj"
COPY . .
WORKDIR "/src/CB.API"
RUN dotnet build "CB.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CB.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "CB.API.dll"]

RUN useradd -m myappuser
USER myappuser

CMD ASPNETCORE_URLS="http://*:$PORT" dotnet CB.API.dll
