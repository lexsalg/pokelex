## Ejecutar api
dotnet run --project PokeLexApi

## Swagger
http://localhost:5000/swagger/index.html

## sql server,EF
dotnet add package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer

## build image 
docker build -t pokelexapi_app .

## up
docker-compose up -d

## update compse
docker-compose up --force-recreate --build -d
docker image prune -f