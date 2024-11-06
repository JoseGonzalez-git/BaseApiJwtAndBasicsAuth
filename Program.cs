using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using BaseApiJwtAndBasicsAuth.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Configuración de la autenticación
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
})
.AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("Basic", null);

builder.Services.AddAuthorization();

// Configura los servicios, incluidos los controladores y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // Necesario para exponer los endpoints a Swagger
builder.Services.AddSwaggerGen(); // Agrega SwaggerGen para generar la interfaz de Swagger

var app = builder.Build();

// Condicional para habilitar Swagger solo en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
    

app.UseRouting();
app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllers();

app.Run();
