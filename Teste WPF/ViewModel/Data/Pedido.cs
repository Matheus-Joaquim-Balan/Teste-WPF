using System;
using System.Collections.Generic;

namespace Teste_WPF.ViewModels
{
    public class Pedido
    {
        public int Id { get; set; }
        public Pessoa Pessoas { get; set; }
        public Produto Produtos { get; set; }
        public double ValorTotal { get; set; }
        public string DataVenda { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public Status Status { get; set; }


        public Pedido()
        {
            Pessoas = new Pessoa();
            Produtos = new Produto();

            this.Id = 1;
            this.ValorTotal = this.Produtos.Valor * this.Produtos.QntProduto;
            this.DataVenda = DateTime.Now.ToString("dd-MM-yyyy");
            this.FormaPagamento = ViewModels.FormaPagamento.Cartão;
            this.Status = Status.Pendente;
        }
    }
}
