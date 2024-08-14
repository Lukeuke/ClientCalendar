namespace CRM.Application.Models;

public class Settings
{
    public string BearerKey { get; set; }
    public int Expiration { get; set; }
    public string Issuer { get; set; }
}