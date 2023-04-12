using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_WPF
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public string Codigo { get; set; }
        public double Valor { get; set; }

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

        public Produto(string nomeProduto)
        {
            NomeProduto = nomeProduto;
        }

        public static class ExportadorJson
        {
        }
    }
}
