using System.Collections.Generic;

namespace NSE.WebApp.MVC.Models
{
    public class CarrinhoViewModel
    {
        public decimal ValorTotal { get; set; }
        public List<ItemCarrinhoViewModel> Itens { get; set; } = new List<ItemCarrinhoViewModel>();
        public bool VoucherUtilizado { get; set; }
        public decimal Desconto { get; set; }
        public VoucherViewModel Voucher { get; set; }
    }
}
