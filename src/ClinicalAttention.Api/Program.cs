using ClinicalAttention.Application;
using ClinicalAttention.Infrastructure;
using ClinicalAttention.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// SERVICES

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Dependency Injection (Hexagonal)
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

//BUILD APP

var app = builder.Build();

//MIDDLEWARE

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Controllers
app.MapControllers();

app.Run();