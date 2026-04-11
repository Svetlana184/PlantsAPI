## Создание API

проверка версии sdk

1. dotnet --version

создание решения

2. dotnet new sln -n APISystem

создание web api

3. dotnet new webapi -n APIPlants

пакеты

4. dotnet add package Microsoft.AspNetCore.Authentification.JwtBearer

5. dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson

6. dotnet add package Microsoft.EntityFrameworkCore.Design

7. dotnet add package Microsoft.EntityFrameworkCore.Tools

8. dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL

запуск проект

9. dotnet watch run
