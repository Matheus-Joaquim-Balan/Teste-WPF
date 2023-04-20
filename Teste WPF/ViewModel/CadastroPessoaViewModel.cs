using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Teste_WPF.ViewModel.Command;

namespace Teste_WPF.ViewModel
{
    public class CadastroPessoaViewModel
    {
        public BotaoComando BotaoComando { get; set; }
        public CadastroPessoaViewModel()
        {
            BotaoComando = new BotaoComando(this);
        }

        public void OnExecute()
        {
            MessageBox.Show("Mostre-me");
        }
    }
}
