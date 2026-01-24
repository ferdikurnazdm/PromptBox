namespace PromptBox.Domain.Entities;

public sealed class Prompt
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public string? Title { get; set; }
    public string? Body { get; set; }


    public Guid UserId { get; set; }
    public User User { get; init; } = null!;

    public ICollection<Payload>? Payloads { get; set; }
}
