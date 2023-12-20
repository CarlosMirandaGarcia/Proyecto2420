using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using VGuitarrasBolivia.Context;

namespace VGuitarrasBolivia.Controllers
{
    public class LoginController : Controller
    {
        private MiContext _context;
        public LoginController(MiContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string correo,string contrasena)
        {
            var usuario = await _context.Usuarios
                                        .Where(x => x.Email == correo && x.Password == contrasena)
                                        .FirstOrDefaultAsync();
            if (usuario != null) 
            {
                return RedirectToAction("Index","Home");
            }
            else
            {
                TempData["LoginError"] = "Cuenta o Contraseña incorrecta!";
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
