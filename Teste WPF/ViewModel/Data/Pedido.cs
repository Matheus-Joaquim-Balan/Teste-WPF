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

       /* List<Pedido> pedidosTeste = new List<Pedido>()
        {
        new Pedido()
        {
            IdPedido = 1,
            Pessoas = new Pessoa() { NomePessoa = "Douglas" },
            Produtos = new Produto() { NomeProduto = "Sapato" },
            ValorTotal = 100,
            DataVenda = "01/01/2022",
            FormaPagamento = FormaPagamento.Cartao,
            Status = Status.Pendente,
            QntProduto = 1
        },
        new Pedido()
        {
            IdPedido = 2,
            Pessoas = new Pessoa() { NomePessoa = "Matheus" },
            Produtos = new Produto() { NomeProduto = "PC Gamer" },
            ValorTotal = 200,
            DataVenda = "02/01/2022",
            FormaPagamento = FormaPagamento.Boleto,
            Status = Status.Pago,
            QntProduto = 2
        },
        new Pedido()
        {
            IdPedido = 3,
            Pessoas = new Pessoa() { NomePessoa = "agafdasd" },
            Produtos = new Produto() { NomeProduto = "Carro" },
            ValorTotal = 300,
            DataVenda = "03/01/2022",
            FormaPagamento = FormaPagamento.Dinheiro,
            Status = Status.Enviado,
            QntProduto = 3
        }
    };*/

    }
}
