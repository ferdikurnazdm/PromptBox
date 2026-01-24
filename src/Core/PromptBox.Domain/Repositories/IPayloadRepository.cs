using PromptBox.Domain.Entities;

namespace PromptBox.Domain.Repositories;

public interface IPayloadRepository
{
    Task AddPayloadAsync(Payload payload);
    Task RemovePayloadAsync(Payload payload);
    Task UpdatePayloadAsync(Payload payload);
    Task<List<Payload>> GetAllPayloadAsync();
    Task<Payload?> GetPayloadByIdAsync(Guid id);
    Task<int> SaveChangesAsync();
}
