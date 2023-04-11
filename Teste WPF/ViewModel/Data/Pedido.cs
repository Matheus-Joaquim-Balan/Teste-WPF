using System;
using System.Collections.Generic;

namespace Teste_WPF
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
        public int QntProduto { get; set; }


        public Pedido()
        {
           
        }

        public Pedido(int id, string nomePessoa, string produtos, double valorTotal, string dataVenda, string formaPagamento)
        {
            Pessoas = new Pessoa();
            Produtos = new Produto();

            Id = id;
            nomePessoa
            ValorTotal = this.Produtos.Valor * this.QntProduto;
            DataVenda = DateTime.Now.ToString("dd-MM-yyyy");
            FormaPagamento = FormaPagamento.Cartão;
            Status = Status.Pendente;
        }
    }
}
