using CRM.Domain.Entities;
using CRM.Infrastructure.Context;
using CRM.Infrastructure.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace CRM.Infrastructure.Repositories.Identity;

public class IdentityRepository : BaseRepository<User>, IIdentityRepository
{
    public IdentityRepository(ApplicationContext context) : base(context)
    {
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
    }
}