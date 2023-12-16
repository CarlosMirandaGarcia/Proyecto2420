using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VGuitarrasBolivia.Context;
using VGuitarrasBolivia.Models;

namespace VGuitarrasBolivia.Controllers
{
    public class LoginController : Controller
    {
        private readonly MiContext _miContext;

        public LoginController(MiContext miContext)
        {
            _miContext = miContext;
        }

        // GET: /Login
        public IActionResult Index()
        {
            // Mostrar la vista del formulario de inicio de sesión
            return View();
        }

        // POST: /Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string Email, string password)
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(password))
            {
                TempData["LoginError"] = "Correo y contraseña son requeridos.";
                return RedirectToAction("Index");
            }

            var usuario = await _miContext.Usuarios
                .FirstOrDefaultAsync(x => x.Email == Email && x.Password == password);

            if (usuario != null) // Usuario encontrado
            {
                // Autenticación exitosa, redirigir a la página principal (por ejemplo, "Home")
                return RedirectToAction("Index", "Home");
            }
            else // Usuario no encontrado o credenciales incorrectas
            {
                TempData["LoginError"] = "Cuenta o contraseña incorrectos.";
                return RedirectToAction("Index");
            }
        }
    }
}
