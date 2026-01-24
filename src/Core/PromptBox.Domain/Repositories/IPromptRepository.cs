using PromptBox.Domain.Entities;

namespace PromptBox.Domain.Repositories;

public interface IPromptRepository
{
    Task AddPromptAsync(Prompt prompt);
    Task RemovePromptAsync(Prompt prompt);
    Task UpdatePromptAsync(Prompt prompt);
    Task<List<Prompt>> GetAllPromptAsync();
    Task<Prompt?> GetPromptByIdAsync(Guid id);
    Task<int> SaveChangesAsync();
}
