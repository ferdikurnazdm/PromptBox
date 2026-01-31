using Microsoft.EntityFrameworkCore;
using PromptBox.Domain.Entities;
using PromptBox.Domain.Repositories;
using PromptBox.Persistence.Context;

namespace PromptBox.Persistence.Repositories;

public sealed class UserRepository : IUserRepository
{
    private readonly AppDbContext _appDbContext;

    public UserRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task AddUserAsync(User user)
    {
        await _appDbContext.Users.AddAsync(user);
    }

    public async Task<List<User>> GetAllUserAsync()
    {
        return await _appDbContext.Users
            .AsNoTracking()
            .ToListAsync();
    }

    public Task<User?> GetUserByEmailAsync(string email)
    {
        return _appDbContext.Users
            .FirstOrDefaultAsync(u => u.Email.Value == email);
    }

    public async Task<User?> GetUserByIdAsync(Guid id)
    {
        return await _appDbContext.Users
            .FindAsync(id);
    }

    public async Task<int> GetUsersCountAsync()
    {
        return await _appDbContext.Users.CountAsync();
    }

    public async Task RemoveUserAsync(User user)
    {
        _appDbContext.Users.Remove(user);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _appDbContext.SaveChangesAsync();
    }

    public async Task UpdateUserAsync(User user)
    {
        _appDbContext.Update(user);
    }
}
