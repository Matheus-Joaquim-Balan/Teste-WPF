using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Teste_WPF.Models;
using Teste_WPF.Services;

namespace Teste_WPF.ViewModel
{
    public class PessoaViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int idPessoaLista { get; set; }
        public ObservableCollection<Pessoa> pessoas { get; set; }

        public RelayCommand PessoaCommand { get; private set; }

        public PessoaViewModel()
        {
            pessoas = new ObservableCollection<Pessoa>()
            {
                try
                { 
            
                var xml = XElement.Load("C:\\Pessoas.xml");

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

                }

                }
                catch
                {
                    return;
                }
        };

    }   

        public void NotifyPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs
                (propertyName));
        }
    }
}
