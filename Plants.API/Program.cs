using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Plants.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Plants.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder
            .AllowAnyMethod()
            .AllowCredentials()
            .SetIsOriginAllowed((host) => true)
            .AllowAnyHeader());
});

// PostgreSQL
builder.Services.AddDbContext<PostgresContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Generic Service

builder.Services.AddScoped<IService<BatchParameter>, BatchParameterService>();
builder.Services.AddScoped<IService<BatchRawMaterial>, BatchRawMaterialService>();
builder.Services.AddScoped<IService<BatchStep>, BatchStepService>();
builder.Services.AddScoped<IService<Department>, DepartmentService>();
builder.Services.AddScoped<IService<Deviation>, DeviationService>();
builder.Services.AddScoped<IService<Equipment>, EquipmentService>();
builder.Services.AddScoped<IService<Event>, EventService>();
builder.Services.AddScoped<IService<LabResult>, LabResultService>();
builder.Services.AddScoped<IService<LabTest>, LabTestService>();
builder.Services.AddScoped<IService<Product>, ProductService>();
builder.Services.AddScoped<IService<ProductionBatch>, ProductionBatchService>();
builder.Services.AddScoped<IService<RawMaterial>, RawMaterialService>();
builder.Services.AddScoped<IService<RawMaterialBatch>, RawMaterialBatchService>();
builder.Services.AddScoped<IService<Recipe>, RecipeService>();
builder.Services.AddScoped<IService<RecipeComponent>, RecipeComponentService>();
builder.Services.AddScoped<IService<StepParameter>, StepParameterService>();
builder.Services.AddScoped<IService<TechMap>, TechMapService>();
builder.Services.AddScoped<IService<TechStep>, TechStepService>();
builder.Services.AddScoped<IService<User>, UserService>();

// Controllers и Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = AuthOptions.ISSUER,
            ValidateAudience = true,
            ValidAudience = AuthOptions.AUDIENCE,
            ValidateLifetime = true,
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true,
        };
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

// Health check
app.MapGet("/", () => "Hello World!");

app.MapPost("/login/api/SignIn", async (User emp, PostgresContext db) =>
{
    User? employee = await db.Users.FirstOrDefaultAsync(p => p.Login == emp.Login && p.PasswordHash == emp.PasswordHash);

    if (employee == null) return Results.Unauthorized();

    var claims = new List<Claim> { new Claim(ClaimTypes.Email, emp.Login) };
    var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(10)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

    var encoderJWT = new JwtSecurityTokenHandler().WriteToken(jwt);
    var response = new
    {
        access_token = encoderJWT,
        username = emp.Login
    };
    return Results.Json(response);
});

app.Run();