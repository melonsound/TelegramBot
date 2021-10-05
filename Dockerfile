#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TgBotAspNet.csproj", "."]
RUN dotnet restore "./TgBotAspNet.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "TgBotAspNet.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TgBotAspNet.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Declare ports above 1024 as an unprivileged non-root user cannot bind to > 1024
ENV ASPNETCORE_URLS http://+:8000;https://+:8443
EXPOSE 8000
EXPOSE 8443

ENV TZ=Europe/Moscow

ENTRYPOINT ["dotnet", "TgBotAspNet.dll"]