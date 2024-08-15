using System.Text;
using CRM.Application.Graphql.Mutations;
using CRM.Application.Graphql.Queries;
using CRM.Application.Models;
using CRM.Application.Services.Identity;
using CRM.Domain.Entities;
using CRM.Infrastructure.Context;
using CRM.Infrastructure.Repositories.Abstraction;
using CRM.Infrastructure.Repositories.Booking;
using CRM.Infrastructure.Repositories.Calendar;
using CRM.Infrastructure.Repositories.Client;
using CRM.Infrastructure.Repositories.Identity;
using CRM.Web.Modules;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var settings = new Settings();
builder.Configuration.Bind("Settings", settings);
builder.Services.AddSingleton(settings);

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    });

builder.Services.AddNpgsql<ApplicationContext>(builder.Configuration.GetConnectionString("PostgreSQL"));

// Identity Services
builder.Services.AddScoped<BaseRepository<User>, IdentityRepository>();
builder.Services.AddScoped<IIdentityRepository, IdentityRepository>();
builder.Services.AddScoped<IIdentityService, IdentityService>();

// Calendar Services
builder.Services.AddScoped<BaseRepository<Calendar>, CalendarRepository>();
builder.Services.AddScoped<ICalendarRepository, CalendarRepository>();

// Client Services
builder.Services.AddScoped<BaseRepository<Client>, ClientRepository>();

// Booking Services
builder.Services.AddScoped<BaseRepository<Booking>, BookingRepository>();
    
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

builder.Services.AddHttpContextAccessor();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<CalendarQuery>()
    .AddMutationType<CalendarMutation>()
    .AddSorting()
    .AddFiltering()
    .AddAuthorization();

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
app.AddIdentityEndpoint();
app.AddBookingEndpoint();
app.AddCalendarEndpoint();

// GraphQL
app.MapGraphQL();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.UseAuthentication();
app.UseAuthorization();

app.MapFallbackToFile("index.html");

app.Run();