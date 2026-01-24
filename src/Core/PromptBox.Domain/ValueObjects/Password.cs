namespace PromptBox.Domain.ValueObjects;

public sealed class Password
{
    public string Value { get; }
    public Password(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentNullException(nameof(value));

        Value = value;
    }
}
