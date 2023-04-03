using System;
using System.Collections.Generic;

namespace Teste_WPF.ViewModels
{
    public class Pedido
    {
        public int id { get; set; }
        public Pessoa pessoas { get; set; }
        public Produto produtos { get; set; }
        public double valorTotal { get; set; }
        public string dataVenda { get; set; }
        public FormaPagamento formaPagamento { get; set; }
        public Status status { get; set; }


        public Pedido()
        {
            pessoas = new Pessoa();
            produtos = new Produto();

            this.id = 1;
            this.valorTotal = this.produtos.valor * this.produtos.qntProduto;
            this.dataVenda = DateTime.Now.ToString("dd-MM-yyyy");
            this.formaPagamento = FormaPagamento.cartão;
            this.status = Status.Pendente;
        }
    }
}
