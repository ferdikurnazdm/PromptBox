using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PromptBox.Domain.Entities;

namespace PromptBox.Persistence.Configurations;

public sealed class PromptConfiguration : IEntityTypeConfiguration<Prompt>
{
    public void Configure(EntityTypeBuilder<Prompt> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .IsRequired();

        builder.Property(x => x.CreatedAt)
               .IsRequired();

        builder.Property(x => x.UserId)
               .IsRequired();

        builder.HasOne(x => x.User)
               .WithMany(x => x.Prompts)
               .HasForeignKey(x => x.UserId);
    }
}
