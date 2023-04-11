using System.Windows;
using PropertyChanged;
using System.Windows.Media;

namespace Teste_WPF
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

    }
}

