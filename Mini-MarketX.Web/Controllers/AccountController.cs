using Microsoft.AspNetCore.Mvc;
using Mini_MarketX.Web.Models;


namespace Mini_MarketX.Web.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
               
                TempData["SuccessMessage"] = "Registro exitoso";
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
    }
}
