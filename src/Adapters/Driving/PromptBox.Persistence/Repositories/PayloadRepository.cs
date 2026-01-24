using Microsoft.EntityFrameworkCore;
using PromptBox.Domain.Entities;
using PromptBox.Domain.Repositories;
using PromptBox.Persistence.Context;

namespace PromptBox.Persistence.Repositories;

public sealed class PayloadRepository : IPayloadRepository
{
    private readonly AppDbContext _appDbContext;

    public PayloadRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task AddPayloadAsync(Payload payload)
    {
        await _appDbContext.Payloads.AddAsync(payload);
    }

    public async Task<List<Payload>> GetAllPayloadAsync()
    {
        return await _appDbContext.Payloads
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Payload?> GetPayloadByIdAsync(Guid id)
    {
        return await _appDbContext.Payloads
            .FindAsync(id);
    }

    public async Task RemovePayloadAsync(Payload payload)
    {
        _appDbContext.Payloads.Remove(payload);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _appDbContext.SaveChangesAsync();
    }

    public async Task UpdatePayloadAsync(Payload payload)
    {
        _appDbContext.Payloads.Update(payload);
    }
}
