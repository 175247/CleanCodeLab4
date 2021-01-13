#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster
EXPOSE 5002

WORKDIR /src/Lab4DivisionCalculationService
COPY . .
RUN dotnet publish "Lab4DivisionCalculationService.csproj" -c Release -o /app/publish

WORKDIR /app/publish
ENTRYPOINT ["dotnet", "Lab4DivisionCalculationService.dll"]