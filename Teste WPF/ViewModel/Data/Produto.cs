using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_WPF.ViewModels
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public string Codigo { get; set; }
        public double Valor { get; set; }
        public int QntProduto { get; set; }

        public Produto()
        {
        }

        public Produto(int idProduto, string nomeProduto, string codigo, double valor)
        {
            IdProduto = idProduto;
            NomeProduto = nomeProduto;
            Codigo = codigo;
            Valor = valor;
        }

        /*
        public Produto()
        {
            this.IdProduto = 1;
            this.NomeProduto = "PC Gamer";
            this.Codigo = "477852";
            this.QntProduto = 56;
            this.Valor = 2499.99;
        }*/
    }
}
