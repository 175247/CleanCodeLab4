Simon Tillström

Arkitektur:
CleanCodeLab4 är vår frontend och innehåller också två containers. Den ena är en databas och den andra är frontend och controller i backend som slussar vidare requests och hanterat databasaktioner.
Dessa requests skulle istället kunna skickas från frontend, men valdes att skickas från backend för simpliciteten.
Detta projekt är av typen MVC.

De andra projekten är uppdelade i microservices som kalkylerar det input som de får in. API Conventions har inte direkt följts överallt i projekten för att fokusera på labbuppgiften istället, som är att skapa microservices.
Varje projekt är sin egen container.
