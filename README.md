## Создание API

1. dotnet --version 
2. dotnet new sln -n APISystem
3. dotnet new webapi -n APIPlants
4. dotnet add package Microsoft.AspNetCore.Authentification.JwtBearer
5. dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson
6. dotnet add package Microsoft.EntityFrameworkCore.Design
7. dotnet add package Microsoft.EntityFrameworkCore.Tools
8. dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
9. dotnet watch run