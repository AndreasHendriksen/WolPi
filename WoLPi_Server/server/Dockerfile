
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR ./app

RUN apt-get update && apt-get install -y etherwake
EXPOSE 8080
EXPOSE 8081
EXPOSE 9/udp

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR ./src
COPY  . ./
RUN dotnet restore 
RUN dotnet publish -c Debug -o /app/publish

From base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "server.dll"]