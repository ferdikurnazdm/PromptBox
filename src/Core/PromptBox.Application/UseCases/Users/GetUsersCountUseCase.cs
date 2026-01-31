using System;
using PromptBox.Domain.Repositories;

namespace PromptBox.Application.UseCases.Users;

public sealed class GetUsersCountUseCase
{
    private readonly IUserRepository _userRepository;

    public GetUsersCountUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<int> ExecuteAsync()
    {
        return await _userRepository.GetUsersCountAsync();
    }
}
