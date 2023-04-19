using System;
using System.Collections.Generic;
using Teste_WPF.Models;

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
        public int UltimoId { get; set; }

        public Pedido()
        {
        }

        public Pedido(int id, string nomePessoa, List<Produto> produtos, double valorTotal, int formaPagamento, int status, int idPedidoLista)
        {
            Produtos = new List<Produto>();

            Produtos = produtos.ConvertAll(x => new Produto { IdProduto = x.IdProduto, NomeProduto = x.NomeProduto, Valor = x.Valor, QntdProduto = x.QntdProduto });

            this.IdPedido = id;
            this.NomePessoa = nomePessoa;
            this.ValorTotal = valorTotal;
            this.DataVenda = DateTime.Now.ToString("dd-MM-yyyy");
            this.FormaPagamento = (FormaPagamento)formaPagamento;
            this.Status = (Status)status;
            this.UltimoId = idPedidoLista;
        }
    }
}
