## Создание API

проверка версии sdk

1. dotnet --version

создание решения

2. dotnet new sln -n APISystem

создание web api

3. dotnet new webapi -n APIPlants

dotnet sln add APISystem/APISystem.csproj

пакеты

4. dotnet add package Microsoft.AspNetCore.Authentification.JwtBearer --version 9.0.0

5. dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson --version 9.0.0

6. dotnet add package Microsoft.EntityFrameworkCore.Design --version 9.0.0

7. dotnet add package Microsoft.EntityFrameworkCore.Tools --version 9.0.0

8. dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 9.0.0

9. dotnet add package Swashbuckle.AspNetCore --version 6.9.0

запуск проект

10. dotnet watch run
