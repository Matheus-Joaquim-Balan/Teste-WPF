using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using Teste_WPF.Models;
using Teste_WPF.Services;

namespace Teste_WPF.ViewModel
{
    public class PessoaViewModel : ICommand
    {        
        public ObservableCollection<Pessoa> Pessoas { get; set; }

        public PessoaViewModel()
        {        
            Pessoa pessoaXML = new Pessoa();
            Pessoas = new ObservableCollection<Pessoa>();
            //Pessoas = pessoaXML.LerXmlPessoa();  
            //pessoaXML.ExportarXmlPessoa(Pessoas);
           
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
