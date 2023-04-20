using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Teste_WPF.ViewModel.Command
{
    public class BotaoComando : ICommand
    {
        CadastroPessoaViewModel _botaoViewModel;

        public BotaoComando(CadastroPessoaViewModel viewModel)
        {
            _botaoViewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _botaoViewModel.OnExecute();
        }
    }
}
