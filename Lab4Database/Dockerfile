#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Lab4Database/Lab4Database.csproj", "Lab4Database/"]
RUN dotnet restore "Lab4Database/Lab4Database.csproj"
COPY . .
WORKDIR "/src/Lab4Database"
RUN dotnet build "Lab4Database.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lab4Database.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lab4Database.dll"]