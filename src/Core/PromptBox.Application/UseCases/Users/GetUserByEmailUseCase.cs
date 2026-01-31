using System;
using PromptBox.Domain.Entities;
using PromptBox.Domain.Repositories;

namespace PromptBox.Application.UseCases.Users;

public sealed class GetUserByEmailUseCase
{
    private readonly IUserRepository _userRepository;

    public GetUserByEmailUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User?> ExecuteAsync(string email)
    {
        return await _userRepository.GetUserByEmailAsync(email);
    }
}
