using NSE.Carrinho.WebAPI.Validations;
using System;

namespace NSE.Carrinho.WebAPI.Model
{
    public class CarrinhoItem
    {
        public CarrinhoItem()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public Guid ProdutoId { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public string Imagem { get; set; }

        //EF RELATION
        public Guid CarrinhoId { get; set; }
        public CarrinhoCliente CarrinhoCliente { get; set; }

        internal bool EhValido()
        {
            return new ItemCarrinhoValidation().Validate(this).IsValid;
        }

        internal void AssociarCarrinho(Guid carrinhoId)
        {
            CarrinhoId = carrinhoId;
        }
        internal decimal CalcularValor()
        {
            return Quantidade * Valor;
        }
        internal void AdicionarUnidades(int unidades)
        {
            Quantidade += unidades;
        }
        internal void AtualizarUnidades(int unidades)
        {
            Quantidade = unidades;
        }
    }
}
