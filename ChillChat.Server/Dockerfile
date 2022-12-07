#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ChillChat.Server/ChillChat.Server.csproj", "ChillChat.Server/"]
RUN dotnet restore "ChillChat.Server/ChillChat.Server.csproj"
COPY . .
WORKDIR "/src/ChillChat.Server"
RUN dotnet build "ChillChat.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ChillChat.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChillChat.Server.dll"]