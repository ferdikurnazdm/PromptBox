using PromptBox.Domain.ValueObjects;

namespace PromptBox.Domain.Entities;

public sealed class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required Email Email { get; init; }
    public required Password Password { get; init; }
    public ICollection<Prompt> Prompts { get; set; } = null!;
}
