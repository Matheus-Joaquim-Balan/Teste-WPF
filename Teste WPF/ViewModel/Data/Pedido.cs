using System;
using System.Collections.Generic;

namespace Teste_WPF
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public Pessoa Pessoas { get; set; }
        public string NomePessoa { get; set; } // aqui
        public List<Produto> Produtos { get; set; }
        public double ValorTotal { get; set; }
        public string DataVenda { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public Status Status { get; set; }
        public int QntProduto { get; set; }

        public Pedido()
        {
        }

        public Pedido(int id, string nomePessoa, List<Produto> produtos, double valorTotal,int formaPagamento ,int status)
        {
            produtos = new List<Produto>();
            
            this.IdPedido = id;
            this.NomePessoa = nomePessoa;
            this.Produtos = produtos;
            this.ValorTotal = valorTotal;
            this.DataVenda = DateTime.Now.ToString("dd-MM-yyyy");
            this.FormaPagamento = (FormaPagamento)formaPagamento;
            this.Status = (Status)status;
        }
    }
}
