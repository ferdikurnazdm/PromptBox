using System;

namespace PromptBox.Domain.Exceptions;

public sealed class UserValidationException : Exception
{
    public List<string> Errors { get; }
    public UserValidationException(List<string> errors) : base("Validasyon hataları oluştu. Detaylar için Errors listesine bakın.")
    {
        Errors = errors;
    }
    public override string Message => $"{base.Message} | " + string.Join(" - ", Errors);
}
