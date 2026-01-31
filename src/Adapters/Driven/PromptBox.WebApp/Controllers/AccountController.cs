using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PromptBox.Application.UseCases.Users;
using PromptBox.Domain.Entities;
using PromptBox.Domain.Repositories;
using PromptBox.Domain.ValueObjects;
using PromptBox.WebApp.Dtos;

namespace PromptBox.WebApp.Controllers;

public class AccountController : Controller
{
    private readonly IUserRepository _userRepository;

    public AccountController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public async Task<ActionResult> Login()
    {
        var getUsersCountUseCase = new GetUsersCountUseCase(_userRepository);

        var usersCount = await getUsersCountUseCase.ExecuteAsync();

        if (usersCount == 0)
            return RedirectToAction("Register", "Account");

        return View();
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        if (!ModelState.IsValid)
            return View(dto);

        var getUserByEmailUseCase = new GetUserByEmailUseCase(_userRepository);

        var user = await getUserByEmailUseCase.ExecuteAsync(dto.Email);

        if (user is null || user.Password.Value != dto.Password)
        {
            ModelState.AddModelError(string.Empty, "Invalid email or password.");
            return View(dto);
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Email.Value)
        };
        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(claimsIdentity);
        
        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            principal,
            new AuthenticationProperties { IsPersistent = dto.RememberMe });
        
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public async Task<ActionResult> Register()
    {
        return View(new RegisterDto("", "", ""));
    }

    [HttpPost]
    public async Task<ActionResult> Register(RegisterDto registerDto)
    {
        var registerUserUseCase = new RegisterUserUseCase(_userRepository);

        var user = new User
        {
            Email = new Email(registerDto.Email),
            Password = new Password(registerDto.Password)
        };

        await registerUserUseCase.ExecuteAsync(user);

        return RedirectToAction("Login", "Account");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        return RedirectToAction("Login", "Account");
    }


}

