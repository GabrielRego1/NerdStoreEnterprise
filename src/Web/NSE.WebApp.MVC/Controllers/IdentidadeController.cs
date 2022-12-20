using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Controllers
{
    public class IdentidadeController : Controller
    {
        [HttpGet("nova-conta")]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost("nova-conta")]
        public async Task<IActionResult> Registro(UsuarioRegistro usuarioRegistro)
        {
            if (!ModelState.IsValid) return View(usuarioRegistro);

            //TODO: api - registro

            if (false) return View(usuarioRegistro);

            //TODO: Realizar login na APP

            return RedirectToAction("Index", "Home");
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login")]
        public IActionResult Login(UsuarioLogin usuarioLogin)
        {
            if (!ModelState.IsValid) return View(usuarioLogin);

            //TODO: api - Login

            if (false) return View(usuarioLogin);

            //TODO: Realizar login na APP

            return RedirectToAction("Index", "Home");
        }

        [HttpGet("sair")]
        public IActionResult Logout()
        {
            //TODO: RETIRAR COOKIES

            return RedirectToAction("Index", "Home");
        }
    }
}
