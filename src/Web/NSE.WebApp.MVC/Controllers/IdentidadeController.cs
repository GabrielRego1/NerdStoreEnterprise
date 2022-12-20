using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models;
using NSE.WebApp.MVC.Services;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Controllers
{
    public class IdentidadeController : Controller
    {
        private readonly IAutenticacaoService _autenticacaoService;

        public IdentidadeController(IAutenticacaoService autenticacaoService)
        {
            _autenticacaoService = autenticacaoService;
        }

        [HttpGet("nova-conta")]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost("nova-conta")]
        public async Task<IActionResult> Registro(UsuarioRegistro usuarioRegistro)
        {
            if (!ModelState.IsValid) return View(usuarioRegistro);

            var response = await _autenticacaoService.Registro(usuarioRegistro);

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
        public async Task<IActionResult> Login(UsuarioLogin usuarioLogin)
        {
            if (!ModelState.IsValid) return View(usuarioLogin);


            var response = await _autenticacaoService.Login(usuarioLogin);


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
