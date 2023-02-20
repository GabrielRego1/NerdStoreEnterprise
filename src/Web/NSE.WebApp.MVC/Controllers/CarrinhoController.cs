using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models;
using NSE.WebApp.MVC.Services;
using System;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Controllers
{
    public class CarrinhoController : MainController
    {
        private readonly ICarrinhoService _carrinhoService;
        private readonly ICatalogoService _catalogoService;

        public CarrinhoController(ICarrinhoService carrinhoService,
                                  ICatalogoService catalogoService)
        {
            _carrinhoService = carrinhoService;
            _catalogoService = catalogoService;
        }


        [Route("carrinho")]
        public async Task<IActionResult> Index()
        {
            return View(await _carrinhoService.ObterCarrinho());
        }

        [HttpPost("carrinho/adicionar-item")]
        public async Task<IActionResult> AdicionarItemCarrinho(ItemProdutoViewModel itemProdutoViewModel)
        {
            var produto = await _catalogoService.ObterPorId(itemProdutoViewModel.ProdutoId);

            itemProdutoViewModel.Nome = produto.Nome;
            itemProdutoViewModel.Valor = produto.Valor;
            itemProdutoViewModel.Imagem = produto.Imagem;

            var result = await _carrinhoService.AdicionarItemCarrinho(itemProdutoViewModel);

            if (ResponsePossuiErros(result))
                return View("Index", await _carrinhoService.ObterCarrinho());

            return RedirectToAction("Index");
        }
        [HttpPost("carrinho/atualizar-item")]
        public async Task<IActionResult> AtualizarItemCarrinho(Guid produtoId, int quantidade)
        {
            var produto = await _catalogoService.ObterPorId(produtoId);

            if (produto == null)
                AdicionarErroValidacao("Produto inexistente");

            var itemProduto = new ItemProdutoViewModel
            {
                ProdutoId = produtoId,
                Quantidade = quantidade
            };

            var result = await _carrinhoService.AtualizarItemCarrinho(produtoId, itemProduto);


            if (ResponsePossuiErros(result))
                return View("Index", await _carrinhoService.ObterCarrinho());


            return RedirectToAction("Index");
        }

        [HttpPost("carrinho/remover-item")]
        public async Task<IActionResult> RemoverItemCarrinho(Guid produtoId)
        {
            var produto = await _catalogoService.ObterPorId(produtoId);

            if (produto == null)
            {
                AdicionarErroValidacao("Produto inexistente");
                return View("Index", await _carrinhoService.ObterCarrinho());
            }

            var result = await _carrinhoService.RemoverItemCarrinho(produtoId);


            if (ResponsePossuiErros(result))
                return View("Index", await _carrinhoService.ObterCarrinho());


            return RedirectToAction("Index");
        }

    }
}
