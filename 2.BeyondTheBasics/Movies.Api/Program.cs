using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Movies.Api.Mapping;
using Movies.Application;
using Movies.Application.Database;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;





builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddDatabase(config["Database:ConnectionString"]!);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthorization();
app.UseMiddleware<ValidationMappingMiddleware>();

app.MapControllers();

var dbInitializer = app.Services.GetRequiredService<DbInitializer>();
await dbInitializer.InitializeAsync();

app.Run();
