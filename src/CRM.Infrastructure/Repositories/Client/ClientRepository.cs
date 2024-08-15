using CRM.Infrastructure.Context;
using CRM.Infrastructure.Repositories.Abstraction;

namespace CRM.Infrastructure.Repositories.Client;

public class ClientRepository : BaseRepository<Domain.Entities.Client>
{
    public ClientRepository(ApplicationContext context) : base(context)
    {
    }
}