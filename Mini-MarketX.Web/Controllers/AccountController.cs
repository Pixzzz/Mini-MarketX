using Microsoft.AspNetCore.Mvc;
using Mini_MarketX.Data.Entities;
using Mini_MarketX.Data.Interfaces;
using Mini_MarketX.Web.Models;


namespace Mini_MarketX.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;

        // Inyectamos el repositorio en el constructor
        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

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
                // Verificar si el correo electrónico ya está en uso
                var existingUser = _userRepository.GetByEmail(model.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError(string.Empty, "El correo electrónico ya está en uso.");
                    return View(model);
                }

                // Crear un nuevo usuario
                var user = new User
                {
                    Username = model.Username,
                    Email = model.Email,
                    Password = model.Password 
                };

                // Agregar el nuevo usuario al repositorio
                _userRepository.Add(user);
               
                TempData["SuccessMessage"] = "Registro exitoso";
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
    }
}
