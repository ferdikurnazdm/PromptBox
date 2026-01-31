using System;
using System.ComponentModel.DataAnnotations;

namespace PromptBox.Domain.ValueObjects;

public sealed class Email
{
    public string Value { get; }

    public Email(string value)
    {
        var validator = new EmailAddressAttribute();
        
        if (string.IsNullOrWhiteSpace(value) || !validator.IsValid(value))
            throw new ArgumentException("Geçersiz email formatı!");

        Value = value;
    }
}