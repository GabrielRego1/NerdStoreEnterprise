using System.Collections.Generic;

namespace NSE.WebApp.MVC.Models
{
    public class CarrinhoViewModel
    {
        public decimal ValorTotal { get; set; }
        public List<ItemProdutoViewModel> Itens { get; set; } = new List<ItemProdutoViewModel>();
    }
}
