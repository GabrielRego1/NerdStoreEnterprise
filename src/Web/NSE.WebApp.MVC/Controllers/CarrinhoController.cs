﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models;
using NSE.WebApp.MVC.Services;
using System;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Controllers
{
    [Authorize]
    public class CarrinhoController : MainController
    {
        private readonly IComprasBffService _carrinhoService;
        private readonly ICatalogoService _catalogoService;

        public CarrinhoController(IComprasBffService carrinhoService,
                                  ICatalogoService catalogoService)
        {
            _carrinhoService = carrinhoService;
            _catalogoService = catalogoService;
        }


        [HttpGet("carrinho")]
        public async Task<IActionResult> Index()
        {
            return View(await _carrinhoService.ObterCarrinho());
        }

        [HttpPost("carrinho/adicionar-item")]
        public async Task<IActionResult> AdicionarItemCarrinho(ItemCarrinhoViewModel itemProdutoViewModel)
        {
            var produto = await _catalogoService.ObterPorId(itemProdutoViewModel.ProdutoId);

            ValidarItemCarrinho(produto, itemProdutoViewModel.Quantidade);
            if (!OperacaoValida())
                return View("Index", await _carrinhoService.ObterCarrinho());

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

            ValidarItemCarrinho(produto, quantidade);
            if (!OperacaoValida())
                return View("Index", await _carrinhoService.ObterCarrinho());

            var itemProduto = new ItemCarrinhoViewModel
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
        private void ValidarItemCarrinho(ProdutoViewModel produtoViewModel, int quantidade)
        {
            if (produtoViewModel == null)
                AdicionarErroValidacao("Produto inexistente!");
            if (quantidade < 1)
                AdicionarErroValidacao($"Escolha ao menos uma unidade do produto {produtoViewModel.Nome}");
            if (quantidade > produtoViewModel.QuantidadeEstoque)
                AdicionarErroValidacao($"O produto {produtoViewModel.Nome} possui {produtoViewModel.QuantidadeEstoque} unidades em estoque, você selecionou {quantidade}");
        }
    }
}
