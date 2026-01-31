using PromptBox.Domain.Entities;

namespace PromptBox.Domain.Repositories;

public interface IUserRepository
{
    Task AddUserAsync(User user);
    Task RemoveUserAsync(User user);
    Task UpdateUserAsync(User user);
    Task<List<User>> GetAllUserAsync();
    Task<User?> GetUserByIdAsync(Guid id);
    Task<User?> GetUserByEmailAsync(string email);
    Task<int> GetUsersCountAsync();
    Task<int> SaveChangesAsync();
}
