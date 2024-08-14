namespace CRM.Web.ClientApp.Modules;

public static class ClientModule
{
    public static void AddClientEndpoint(this WebApplication app)
    {
        app.MapGet("/api/client/{id}", (Guid clientId) =>
        {
            
        });
    }
}