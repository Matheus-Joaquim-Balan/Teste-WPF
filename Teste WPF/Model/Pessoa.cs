using System.Windows;
using PropertyChanged;
using System.Windows.Media;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Teste_WPF.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Pessoa
    {
        public int IdPessoa { get; set; }
        public string NomePessoa { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
        public Brush Cor { get; set; }

        public Pessoa()
        {
            Cor = Brushes.Red;
        }
        public Pessoa(int id, string nome, string cpf, string endereco)
        {
            IdPessoa = id;
            NomePessoa = nome;
            CPF = cpf;
            Endereco = endereco;
            Cor = Brushes.Red;
        }


        public static bool ValidaCpf(string cpf)
	     {
		    int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
		    int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
		    string tempCpf;
		    string digito;
		    int soma;
		    int resto;
		    cpf = cpf.Trim();
		    cpf = cpf.Replace(".", "").Replace("-", "");
		    if (cpf.Length != 11)
		       return false;
		    tempCpf = cpf.Substring(0, 9);
		    soma = 0;

		    for(int i=0; i<9; i++)
		        soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
		    resto = soma % 11;
		    if ( resto < 2 )
		        resto = 0;
		    else
		       resto = 11 - resto;
		    digito = resto.ToString();
		    tempCpf = tempCpf + digito;
		    soma = 0;
		    for(int i=0; i<10; i++)
		        soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
		    resto = soma % 11;
		    if (resto < 2)
		       resto = 0;
		    else
		       resto = 11 - resto;
		    digito = digito + resto.ToString();
		    return cpf.EndsWith(digito);
	     }

        private void ExportarXmlPessoa(string fileName, int idPessoaLista)
        {
            var xml = new XElement("Pessoa",
                new XElement("IdPessoaLista", idPessoaLista),
                from p in pessoas
                select new XElement("Pessoa",
                    new XElement("IdPessoa", p.IdPessoa),
                    new XElement("NomePessoa", p.NomePessoa),
                    new XElement("CPF", p.CPF),
                    new XElement("Endereco", p.Endereco)
                )
            );
            xml.Save(fileName);
        }

        private void LerXmlPessoa(string fileName, int idPessoaLista)
        {
            try
            {
                var xml = XElement.Load(fileName);

                idPessoaLista = int.Parse(xml.Element("IdPessoaLista").Value);

                foreach (var element in xml.Elements("Pessoa"))
                {
                    var pessoa = new Pessoa
                    {
                        IdPessoa = int.Parse(element.Element("IdPessoa").Value),
                        NomePessoa = element.Element("NomePessoa").Value,
                        CPF = element.Element("CPF").Value,
                        Endereco = element.Element("Endereco").Value,
                    };
                    Pessoa(pessoa);
                }
            }
            catch
            {
                return;
            }
        }

    }
}

