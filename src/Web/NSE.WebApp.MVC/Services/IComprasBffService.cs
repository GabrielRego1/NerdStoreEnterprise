﻿using NSE.Core.Communication;
using NSE.WebApp.MVC.Models;
using System;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Services
{
    public interface IComprasBffService
    {
        Task<CarrinhoViewModel> ObterCarrinho();
        Task<int> ObterQuantidadeCarrinho();
        Task<ResponseResult> AdicionarItemCarrinho(ItemCarrinhoViewModel produto);
        Task<ResponseResult> AtualizarItemCarrinho(Guid produtoId, ItemCarrinhoViewModel produto);
        Task<ResponseResult> RemoverItemCarrinho(Guid produtoId);
        Task<ResponseResult> AplicarVoucherCarrinho(string voucher);
        PedidoTransacaoViewModel MapearParaPedido(CarrinhoViewModel carrinho, EnderecoViewModel endereco);

    }
}
