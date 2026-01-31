using Microsoft.AspNetCore.Mvc;

namespace PromptBox.WebApp.Controllers;

public class AccountController : Controller
{
    [HttpGet]
    public ActionResult Login()
    {
        return View();
    }

    // public async Task<ActionResult> Logout()
    // {
    //     await HttpContext.SignOutAsync();
    //     return RedirectToAction("Index", "Home");
    // }


}

