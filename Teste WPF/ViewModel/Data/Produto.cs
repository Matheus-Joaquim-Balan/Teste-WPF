using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_WPF.ViewModels
{
    public class Produto
    {
        public int idProduto { get; set; }
        public string nomeProduto { get; set; }
        public string codigo { get; set; }
        public double valor { get; set; }
        public int qntProduto { get; set; }
     
        public Produto()
        {
            this.idProduto = 1;
            this.nomeProduto = "PC Gamer";
            this.codigo = "477852";
            this.qntProduto = 56;
            this.valor = 2499.99;
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
