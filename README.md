!! OBS !!
På grund av tidsbrist / att vi båda hade tid då den andre inte hade tid så har vi valt att dela upp vårt arbete
i två egna delar. Under simon-dev har vi Simons version och under molnar-dev har vi min (Alexanders) version.
Detta beror alltså inte på några negativa händelser eller känslor mellan oss, utan pga tid.

Simon Tillström

Arkitektur:
CleanCodeLab4 är vår frontend och innehåller också två containers. Den ena är en databas och den andra är frontend och controller i backend som slussar vidare requests och hanterat databasaktioner.
Dessa requests skulle istället kunna skickas från frontend, men valdes att skickas från backend för simpliciteten.
Detta projekt är av typen MVC.

De andra projekten är uppdelade i microservices som kalkylerar det input som de får in. API Conventions har inte direkt följts överallt i projekten för att fokusera på labbuppgiften istället, som är att skapa microservices.
Varje projekt är sin egen container.


Alexander Molnar

Arkitektur:
CleanCodeLab4 är vår frontend som tar emot input från UI't.
När UIt's inputs har blivit submittade kallas respektive microservice (i form av de olika uträknelseformerna) via ett
API-anrop, där sedan svaret visas för användaren i UI't, och även sparas ner i databasen, där jag valde att använda mig
av MySQL.

Hela flödet startas upp via Docker Compose, och varje del (projekt) är en separat microservice i sin egen container.

När Docker Compose startar upp allt i sitt flöde körs även Cypress-E2E test, som går igenom ett av flödena från början till slut.
Man hade kunnat testa samtliga flöden, men det hade bara blivit repetativ och överflödig kod, därför valdes detta bort.

Projektet har från början till slut testats rigoröst med både Swagger, Adminer samt MySQLWorkbench för att säkerställa
att allt går rätt till. (Både Swagger och Adminer finns att tillgå via sina egna portar, uppgår tydligt vad dessa
portar är i Docker Compose om man vill testa via dessa).
