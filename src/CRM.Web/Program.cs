using System.Text;
using CRM.Application.Models;
using CRM.Application.Queries;
using CRM.Application.Services.Identity;
using CRM.Domain.Entities;
using CRM.Infrastructure.Context;
using CRM.Infrastructure.Repositories.Abstraction;
using CRM.Infrastructure.Repositories.Identity;
using CRM.Web.Modules;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var settings = new Settings();
builder.Configuration.Bind("Settings", settings);
builder.Services.AddSingleton(settings);

builder.Services.AddControllersWithViews();

builder.Services.AddNpgsql<ApplicationContext>(builder.Configuration.GetConnectionString("PostgreSQL"));

builder.Services.AddScoped<BaseRepository<User>, IdentityRepository>();
builder.Services.AddScoped<IIdentityRepository, IdentityRepository>();
builder.Services.AddScoped<IIdentityService, IdentityService>();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => 
    options.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(settings.BearerKey)),
        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        ValidIssuer = settings.Issuer,
        ValidateIssuer = true
    });

builder.Services
    .AddGraphQLServer()
    .AddQueryType<CalendarQuery>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// REST API
app.AddClientEndpoint();
app.AddIdentityEndpoint();

// GraphQL
app.MapGraphQL();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.UseAuthentication();
app.UseAuthorization();

app.MapFallbackToFile("index.html");

app.Run();