using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PromptBox.WebApp.Areas.Setup.Controllers;

[Area("Setup")]
[AllowAnonymous]
[Route("Setup")]
public class SetupController : Controller
{
    [HttpGet("")]
    public IActionResult Index() => View();

    [HttpPost("")]
    [ValidateAntiForgeryToken]
    public IActionResult Initialize()
    {
        // setup logic
        return Redirect("/");
    }
}
