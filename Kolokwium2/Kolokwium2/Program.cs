using Kolokwium2.Data;
using Kolokwium2.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<EntityFrameworkContext>(
    options => options.UseSqlServer("Name=ConnectionStrings:Default"));
builder.Services.AddScoped<IDbService, DbService>();

var app = builder.Build();

//dotnet tool install --global dotnet-ef
//dotnet ef migrations add Init
//dotnet ef database update

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();



app.Run();