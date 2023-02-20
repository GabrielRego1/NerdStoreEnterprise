using System;
using System.Collections.Generic;

namespace NSE.Carrinho.WebAPI.Model
{
    public class CarrinhoCliente
    {
        public CarrinhoCliente() { }//CTOR para o EF utilizar
        public CarrinhoCliente(Guid clienteId)
        {
            Id = Guid.NewGuid();
            ClienteId = clienteId;
        }
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public decimal ValorTotal { get; set; }
        public List<CarrinhoItem> Itens { get; set; } = new List<CarrinhoItem>();


    }
}
