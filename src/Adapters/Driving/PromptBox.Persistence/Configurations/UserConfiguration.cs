using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PromptBox.Domain.Entities;
using PromptBox.Domain.ValueObjects;

namespace PromptBox.Persistence.Configurations;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .IsRequired();

        builder.Property(x => x.Email)
               .HasMaxLength(100)
               .IsRequired()
               .HasConversion(
                 toDb => toDb.Value,
                 fromDb => new Email(fromDb));

        builder.Property(x => x.Password)
               .HasMaxLength(100)
               .IsRequired()
               .HasConversion(
                 toDb => toDb.Value,
                 fromDb => new Password(fromDb));
    }
}
