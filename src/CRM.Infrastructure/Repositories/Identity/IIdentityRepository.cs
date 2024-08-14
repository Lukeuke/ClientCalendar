using CRM.Domain.Entities;

namespace CRM.Infrastructure.Repositories.Identity;

public interface IIdentityRepository
{
    Task<User?> GetUserByEmailAsync(string email);
}