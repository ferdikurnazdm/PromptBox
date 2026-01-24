using Microsoft.EntityFrameworkCore;
using PromptBox.Domain.Entities;
using PromptBox.Persistence.Configurations;

namespace PromptBox.Persistence.Context;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Payload> Payloads { get; set; }
    public DbSet<Prompt> Prompts { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new PayloadConfiguration());
        modelBuilder.ApplyConfiguration(new PromptConfiguration());

    }
}
