using System.Windows;
using PropertyChanged;
using System.Windows.Media;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Collections.ObjectModel;
using System.Linq;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;

namespace Teste_WPF.Models
{
    public class Pessoa : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string nomePropriedade)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nomePropriedade));
        }

        private int _idPessoa;    
        private string _nomePessoa { get; set; }
        private string _CPF { get; set; }
        private string _endereco { get; set; }
        private int _idPessoaLista { get; set; }

        public int IdPessoa
        {
            get { return _idPessoa; }
            set
            {
                _idPessoa = value;
                OnPropertyChanged("IdPessoa");
            }
        }

        public string NomePessoa
        {
            get { return _nomePessoa; }
            set
            {
                _nomePessoa = value;
                OnPropertyChanged("NomePessoa");
            }
        }

        public string CPF
        {
            get { return _CPF; }
            set
            {
                _CPF = value;
                OnPropertyChanged("CPF");
            }
        }

        public string Endereco
        {
            get { return _endereco; }
            set
            {
                _endereco = value;
                OnPropertyChanged("Endereco");
            }
        }

        public int IdPessoaLista
        {
            get { return _idPessoaLista; }
            set
            {
                _idPessoaLista = value;
                OnPropertyChanged("IdPessoaLista");
            }
        }

        public Pessoa()
        {

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

        public void ExportarXmlPessoa(ObservableCollection<Pessoa> pessoas)
        {
            var arquivoXml = @"C:\\Pessoas.xml";
            using (var stream = new StreamWriter(arquivoXml))
            {
                XmlSerializer serializador = new XmlSerializer(typeof(ObservableCollection<Pessoa>));
                serializador.Serialize(stream, pessoas);
            }
        }

        public ObservableCollection<Pessoa> LerXmlPessoa()
        {
            ObservableCollection<Pessoa> pessoas = new ObservableCollection<Pessoa>();
            try
            {
                var arquivoXml = @"C:\\Pessoas.xml";
                using (StreamReader stream = new StreamReader(arquivoXml))
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(ObservableCollection<Pessoa>));
                    pessoas = (ObservableCollection<Pessoa>)serializador.Deserialize(stream);
                }
                return pessoas;
            }
            catch
            {
                return pessoas;
            }
        }

    }
}

