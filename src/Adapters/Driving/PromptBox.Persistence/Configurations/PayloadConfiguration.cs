using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PromptBox.Domain.Entities;

namespace PromptBox.Persistence.Configurations;

public sealed class PayloadConfiguration : IEntityTypeConfiguration<Payload>
{
    public void Configure(EntityTypeBuilder<Payload> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .IsRequired();

        builder.Property(x => x.Label)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(x => x.PromptId)
               .IsRequired();

        builder.HasOne(x => x.Prompt)
               .WithMany(x => x.Payloads)
               .HasForeignKey(x => x.PromptId);
    }
}
