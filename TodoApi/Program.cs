using Microsoft.EntityFrameworkCore;
using Npgsql;
using PetToolAPI.Models;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Add postgres SQL connection
var connectionString = builder.Configuration.GetConnectionString(
    "PetToolDB");
var dbPassword = builder.Configuration.GetValue<string>(
    "Secrets:PetToolDBPass");
var connStrbuilder = new NpgsqlConnectionStringBuilder(connectionString)
{
    Password = dbPassword
};
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseNpgsql(connStrbuilder.ConnectionString));

Debug.WriteLine("contr = " + connectionString);
Debug.WriteLine(dbPassword);


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "PetToolsApi", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PetToolsApi v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
