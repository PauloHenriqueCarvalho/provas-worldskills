using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using TarefaAPI_v2.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(o =>
{
    o.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=tarefasdb_v2;Trusted_Connection=True;TrustServerCertificate=True");
});
builder.Services.AddControllers().AddJsonOptions(o =>
{
    o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
