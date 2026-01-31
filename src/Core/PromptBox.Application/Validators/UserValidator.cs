using System;
using PromptBox.Domain.Entities;
using PromptBox.Domain.Exceptions;

namespace PromptBox.Application.Validators;

public sealed class UserValidator
{
    private readonly User _user;
    private readonly List<string> _errors;
    private readonly bool _halted;

    public UserValidator(User user)
    {
        _user = user;
        _errors = new List<string>();
        _halted = false;
    }

    public UserValidator MustBeValidEmail()
    {
        if (_halted) return this;

        if (string.IsNullOrWhiteSpace(_user.Email.Value) || !_user.Email.Value.Contains("@"))
        {
            _errors.Add("Invalid email address.");
        }

        return this;
    }

    public UserValidator MustHaveStrongPassword()
    {
        if (_halted) return this;

        if (string.IsNullOrWhiteSpace(_user.Password.Value) || _user.Password.Value.Length < 8)
        {
            _errors.Add("Password must be at least 8 characters long.");
        }

        return this;
    }


    public void ThrowIfInvalid()
    {
        if (_errors.Any())
            throw new UserValidationException(_errors);
    }
    
}
