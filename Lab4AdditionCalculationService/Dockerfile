#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster
EXPOSE 5001

WORKDIR /src/Lab4AdditionCalculationService
COPY . .
RUN dotnet publish "Lab4AdditionCalculationService.csproj" -c Release -o /app/publish

WORKDIR /app/publish
ENTRYPOINT ["dotnet", "Lab4AdditionCalculationService.dll"]