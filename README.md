DEPENDANCES:

- RabbitMq (https://www.rabbitmq.com/)
- MongoDB (https://www.mongodb.com/)
- SQL SERVER 2017 (https://www.microsoft.com/fr-fr/sql-server/sql-server-2017)
- DOCKER (https://www.docker.com/community-edition)

RUN BACKEND

docker-machine start <machine_name>      // default machine_name is 'default'

Windows only: setx ASPNETCORE_ENVIRONMENT "Production"

- docker run -d -p 27017:27017 mongo
- docker run -p 5672:5672 rabbitmq
- docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=kapul12345&' -p 1433:1433 --name kapul -d microsoft/mssql-server-linux:2017-latest

- in Backend/src/Kapul.Api: dotnet run
- in Backend/src/Kapul.Services.Identity: dotnet run --urls "http://*5051"
- in Backend/src/Kapul.Services.Trajet: dotnet run --urls "http://*5050"

RUN FRONTEND

in Frontend:
- npm install
- npm start

RESULT

- Frontend will run at "http://localhost:8080"
- Backend will run at "http://localhost:5000"
