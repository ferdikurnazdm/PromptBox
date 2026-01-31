using System;
using PromptBox.Application.Validators;
using PromptBox.Domain.Entities;
using PromptBox.Domain.Repositories;

namespace PromptBox.Application.UseCases.Users;

public sealed class RegisterUserUseCase
{
    private readonly IUserRepository _userRepository;

    public RegisterUserUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task ExecuteAsync(User user)
    {
        new UserValidator(user)
            .MustBeValidEmail()
            .MustHaveStrongPassword()
            .ThrowIfInvalid();

        await _userRepository.AddUserAsync(user);
        await _userRepository.SaveChangesAsync();
        
    }
}
