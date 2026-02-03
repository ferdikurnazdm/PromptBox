using Microsoft.AspNetCore.Authentication.Cookies;
using PromptBox.Domain.Repositories;
using PromptBox.Persistence.Extensions;
using PromptBox.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// aspire
builder.AddServiceDefaults();

// configurations
builder.Configuration.SetBasePath(builder.Environment.ContentRootPath);
builder.Configuration.AddJsonFile($"Configurations/appsettings.json", optional: false, reloadOnChange: true);
builder.Configuration.AddJsonFile($"Configurations/appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);
builder.Configuration.AddJsonFile($"Configurations/loggingsettings.json", optional: false, reloadOnChange: true);
builder.Configuration.AddJsonFile($"Configurations/loggingsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);
builder.Configuration.AddJsonFile($"Configurations/databasesettings.json", optional: false, reloadOnChange: true);
builder.Configuration.AddJsonFile($"Configurations/databasesettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

// logging

// services 
builder.Services.AddControllersWithViews();
builder.Services.AddAppDatabase(builder.Configuration);
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
        options.AccessDeniedPath = "/Account/Login";
        options.ExpireTimeSpan = TimeSpan.FromDays(7);
        options.SlidingExpiration = true;
    });

builder.Services.AddAuthorization();


var app = builder.Build();



// middlewares
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

await app.ApplyMigrationsAsync();

app.MapDefaultEndpoints();

app.Run();
