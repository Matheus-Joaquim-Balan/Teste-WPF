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
        public string NomeProduto { get; set; } // aqui
        public double ValorTotal { get; set; }
        public string DataVenda { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public Status Status { get; set; }
        public int QntProduto { get; set; }

        public Pedido()
        {
           
        }

        public Pedido(int id, string nomePessoa, List<Produto> produtos, double valor, int formaPagamento ,int status)
        {

            
            this.IdPedido = id;
            this.NomePessoa = nomePessoa;
            this.Produtos = produtos;
            this.DataVenda = DateTime.Now.ToString("dd-MM-yyyy");
            this.ValorTotal = valor;
            this.FormaPagamento = (FormaPagamento)formaPagamento;
            this.Status = (Status)status;
        }
    }
}
