using System;
using System.Collections.Generic;

namespace Teste_WPF
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public Pessoa Pessoas { get; set; }
        public string NomePessoa { get; set; } // aqui
        public Produto Produtos { get; set; }
        public string NomeProduto { get; set; } // aqui
        public double ValorTotal { get; set; }
        public string DataVenda { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public Status Status { get; set; }
        public int QntProduto { get; set; }

        public Pedido()
        {
        }

        public Pedido(int id, string nomePessoa, string produtos, double valorTotal, int formaPagamento ,int status)
        {
            Pessoas = new Pessoa();
            Produtos = new Produto();

            this.IdPedido = 1;
            this.NomePessoa = nomePessoa;
            this.NomeProduto = produtos;
            this.ValorTotal = valorTotal;
            this.DataVenda = DateTime.Now.ToString("dd-MM-yyyy");
            this.FormaPagamento = (FormaPagamento)formaPagamento;
            this.Status = (Status)status;
        }
    }
}
