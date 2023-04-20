using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Teste_WPF.ViewModel;

namespace Teste_WPF.View
{
    /// <summary>
    /// Interação lógica para CadastroPessoaView.xam
    /// </summary>
    public partial class CadastroPessoaView : UserControl
    {
        public CadastroPessoaView()
        {
            InitializeComponent();
            DataContext = new CadastroPessoaViewModel();
        }
    }
}
