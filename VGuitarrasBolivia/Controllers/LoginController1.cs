using VGuitarrasBolivia.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace VGuitarrasBolivia.Context
{
    public class LoginController : Controller
    {
        MiContext _miContext;
        public LoginController(MiContext miContext)
        {
            _miContext = miContext;
        }

        //GET
        public IActionResult Index()
        {
            //para que muestre la pantalla del login
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string correo, string contrasena)
        {
            var usuario = await _miContext.Usuarios
                            .Where(x => x.Email == correo && x.Password == contrasena)
                            .FirstOrDefaultAsync();

            if (usuario != null) //se ha encontrado al usuario
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["LoginError"] = "Cuenta o Password incorrectos";
                return Redirect("Index");
            }
        }
    }
}