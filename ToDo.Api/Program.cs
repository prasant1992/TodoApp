using ToDo.Api.Configs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddServicesConfig();
builder.Services.AddControllers();
builder.Services.AddCors();

builder.Services.AddScoped<ToDoServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.UseCors(policy => policy
    .AllowAnyHeader()
    .AllowAnyMethod()
    .WithOrigins("http://localhost:4200", "https://localhost:4200"));

app.MapControllers();

app.Run();
