using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using PetToolAPI.Data;
using PetToolAPI.Models;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add postgres SQL connection
var connectionString = builder.Configuration.GetConnectionString(
    "PetToolDB");
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseNpgsql(connectionString));
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AppDbContext>();

// Intializes identity server
builder.Services.AddIdentityServer()
    .AddApiAuthorization<AppUser, AppDbContext>();
// Configures the app to validate JWT tokens produced by IdentityServer
builder.Services.AddAuthentication()
    .AddIdentityServerJwt();

//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("ElevatedRights", policy =>
//          policy.RequireRole("Administrator", "PowerUser", "BackupAdministrator"));
//});

builder.Services.AddControllers();


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

app.UseAuthentication();
app.UseIdentityServer();
app.UseAuthorization();

app.MapControllers();

app.Run();
