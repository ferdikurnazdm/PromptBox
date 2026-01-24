using Microsoft.EntityFrameworkCore;
using PromptBox.Domain.Entities;
using PromptBox.Domain.Repositories;
using PromptBox.Persistence.Context;

namespace PromptBox.Persistence.Repositories;

public sealed class PromptRepository : IPromptRepository
{
    private readonly AppDbContext _appDbContext;

    public PromptRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task AddPromptAsync(Prompt prompt)
    {
        await _appDbContext.Prompts.AddAsync(prompt);
    }

    public async Task<List<Prompt>> GetAllPromptAsync()
    {
        return await _appDbContext.Prompts
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Prompt?> GetPromptByIdAsync(Guid id)
    {
        return await _appDbContext.Prompts.FindAsync(id);
    }

    public async Task RemovePromptAsync(Prompt prompt)
    {
        _appDbContext.Prompts.Remove(prompt);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _appDbContext.SaveChangesAsync();
    }

    public async Task UpdatePromptAsync(Prompt prompt)
    {
        _appDbContext.Prompts.Update(prompt);
    }
}
