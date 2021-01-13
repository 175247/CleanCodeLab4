#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster
EXPOSE 80
EXPOSE 443

WORKDIR /src
COPY ./Lab4MySql ./Lab4MySql
COPY ./Lab4Models ./Lab4Models
RUN dotnet publish "./Lab4MySql/Lab4MySql.csproj" -c Release -o /app/publish

WORKDIR /app/publish
ENTRYPOINT ["dotnet", "Lab4MySql.dll"]