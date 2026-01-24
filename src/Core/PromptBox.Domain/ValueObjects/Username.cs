namespace PromptBox.Domain.ValueObjects;

public sealed class Username
{
    public string Value { get; }
    public Username(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentNullException(nameof(value));

        Value = value.Trim();
    }
}
