namespace PromptBox.Domain.Entities;

public sealed class Payload
{
    public Guid Id { get; set; }

    public required string Label { get; init; }
    public required string Value { get; init; }

    public Guid PromptId { get; set; }
    public Prompt Prompt { get; set; } = null!;
}
