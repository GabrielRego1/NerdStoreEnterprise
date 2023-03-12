﻿using Microsoft.AspNetCore.Mvc.Razor;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace NSE.WebApp.MVC.Extensions
{
    public static class RazorHelpers
    {
        public static string MensagemEstoque(this RazorPage page, int quantidade)
            => quantidade > 0 ? $"Apenas {quantidade} em estoque!" : "Produto Esgotado";

        public static string FormatoMoeda(this RazorPage page, decimal valor)
            => valor > 0 ? string.Format(Thread.CurrentThread.CurrentCulture, "{0:C}", valor) : "Gratuito";
        private static string FormatoMoeda(decimal valor)
            => string.Format(Thread.CurrentThread.CurrentCulture, "{0:C}", valor);


        public static string UnidadesPorProdutoValorTotal(this RazorPage page, int unidades, decimal valor)
            => $"{unidades}x {FormatoMoeda(valor)} = Total: {FormatoMoeda(valor * unidades)}";


        public static string HashEmailForGravatar(this RazorPage page, string email)
        {
            var md5Hasher = MD5.Create();
            var data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(email));
            var sBuilder = new StringBuilder();
            foreach (var t in data)
            {
                sBuilder.Append(t.ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public static string UnidadesPorProdutos(this RazorPage page, int unidades) => unidades < 1 ? $"{unidades} unidades" : $"{unidades} unidade";

        public static string SelectOptionsPorQuantidade(this RazorPage page, int quantidade, int valorSelecionado = 0)
        {
            var sb = new StringBuilder();
            for (var i = 1; i <= quantidade; i++)
            {
                var selected = "";
                if (i == valorSelecionado) selected = "selected";
                sb.Append($"<option {selected} value='{i}'>{i}</option>");
            }

            return sb.ToString();
        }
    }
}
