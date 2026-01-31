using System;

namespace PromptBox.WebApp.Dtos;

public sealed record RegisterDto(string Fullname, string Email, string Password);
