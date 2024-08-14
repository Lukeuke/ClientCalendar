using CRM.Application.Queries;
using CRM.Infrastructure.Context;
using CRM.Web.ClientApp.Modules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services
    .AddGraphQLServer()
    .AddQueryType<CalendarQuery>();

builder.Services.AddNpgsql<ApplicationContext>(builder.Configuration.GetConnectionString("PostgreSQL"));

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

// GraphQL
app.MapGraphQL();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();