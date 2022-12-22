using Microsoft.AspNetCore.Mvc;
using System;

namespace NSE.WebApp.MVC.Controllers
{
    public class CatalogoController : Controller
    {
        [HttpGet]
        [Route("")]
        [Route("vitrine")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("produto-detalhe/{id}")]
        public IActionResult ProdutoDetalhe(Guid id)
        {
            return View();
        }


    }
}
