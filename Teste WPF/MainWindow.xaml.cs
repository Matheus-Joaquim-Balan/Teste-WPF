using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Teste_WPF.ViewModels;
using System.Linq;
using System.Collections.ObjectModel;
using System.Data;

namespace Teste_WPF
{

    public partial class MainWindow : Window
    {

        private Pessoa pessoa;
        private Produto produto;
        private ObservableCollection<Pessoa> pessoas;
        private ObservableCollection<Produto> produtos;
        public int IdPessoaLista { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            pessoas = new ObservableCollection<Pessoa>();
            produtos = new ObservableCollection<Produto>();
            pessoa = new Pessoa();
            produto = new Produto();

            GerarTreeViewPedido tree = new GerarTreeViewPedido();         
            TreeViewItem level1_TVI = new TreeViewItem();            
            Pedido pedido = new Pedido();           
            level1_TVI.Header = "Pedido " + pedido.Id;           
            level1_TVI.Items.Add(tree.GerarTreePedidoLevel2(pedido));           
            TreeViewPedido.Items.Add(level1_TVI);
        }

        private void AbrirPessoa(object sender, RoutedEventArgs e)
        {
           
            dataGridPessoa.Visibility = Visibility.Visible;
            btnsPessoa.Visibility = Visibility.Visible;
            gridPesquisaPessoa.Visibility = Visibility.Visible;

            gridCadastrarProduto.Visibility = Visibility.Collapsed;
            gridCadastrarPessoa.Visibility = Visibility.Collapsed;
            TreeViewPedido.Visibility = Visibility.Collapsed;
            btnsPedido.Visibility = Visibility.Collapsed;
            btnsProduto.Visibility = Visibility.Collapsed;
            dataGridProduto.Visibility = Visibility.Collapsed;

            btnPessoa.Background = Brushes.LightGray;
            btnProduto.Background = Brushes.Transparent;
            btnPedido.Background = Brushes.Transparent;

            dataGridPessoa.ItemsSource = pessoas;
        }

        private void AbrirProduto(object sender, RoutedEventArgs e)
        {
            btnsProduto.Visibility = Visibility.Visible;
            dataGridProduto.Visibility = Visibility.Visible;

            dataGridPessoa.Visibility = Visibility.Collapsed;
            gridCadastrarPessoa.Visibility = Visibility.Collapsed;
            gridCadastrarProduto.Visibility = Visibility.Collapsed;
            TreeViewPedido.Visibility = Visibility.Collapsed;
            btnsPessoa.Visibility = Visibility.Collapsed;
            btnsPedido.Visibility = Visibility.Collapsed;
            gridPesquisaPessoa.Visibility = Visibility.Collapsed;

            btnPessoa.Background = Brushes.Transparent;
            btnProduto.Background = Brushes.LightGray;
            btnPedido.Background = Brushes.Transparent;

            dataGridProduto.ItemsSource = produtos;

        }

        private void AbrirPedido(object sender, RoutedEventArgs e)
        {
            TreeViewPedido.Visibility = Visibility.Visible;
            btnsPedido.Visibility = Visibility.Visible;

            dataGridPessoa.Visibility = Visibility.Collapsed;
            gridCadastrarPessoa.Visibility = Visibility.Collapsed;
            gridCadastrarProduto.Visibility = Visibility.Collapsed;
            btnsPessoa.Visibility = Visibility.Collapsed;
            btnsProduto.Visibility = Visibility.Collapsed;
            gridPesquisaPessoa.Visibility = Visibility.Collapsed;
            dataGridProduto.Visibility = Visibility.Collapsed;

            btnPessoa.Background = Brushes.Transparent;
            btnProduto.Background = Brushes.Transparent;
            btnPedido.Background = Brushes.LightGray;            
        }

        #region Botões Pessoa
        private void BtnCadastrarPessoa_Click(object sender, RoutedEventArgs e)
        {
            gridCadastrarPessoa.Visibility = Visibility.Visible;

            dataGridPessoa.Visibility = Visibility.Collapsed;
            gridCadastrarProduto.Visibility = Visibility.Collapsed;
            TreeViewPedido.Visibility = Visibility.Collapsed;
            gridPesquisaPessoa.Visibility = Visibility.Collapsed;

            if (pessoas.Count < 1)
            {
                IdPessoaLista = 1;
                idPessoaBox.Text = $"{IdPessoaLista}";
            }
            else           
                idPessoaBox.Text = $"{IdPessoaLista}";              
        }

        private void BtnSalvarPessoa_Click(object sender, RoutedEventArgs e)
        {
            SalvarPessoa();
        }

        private void BtnCancelarPessoa_Click(object sender, RoutedEventArgs e)
        {
            nomePessoaBox.Text = "";
            CPFBox.Text = "";
            EnderecoBox.Text = "";

            dataGridPessoa.Visibility = Visibility.Visible;
            gridCadastrarPessoa.Visibility = Visibility.Collapsed;
            gridPesquisaPessoa.Visibility = Visibility.Visible;

        }

        private void BtnPesquisarNomeCPF_Click(object sender, RoutedEventArgs e)
        {          
            var dadosGrid = pessoas.Where(g => g.NomePessoa.Contains(txtBoxPesquisaPessoa.Text) || g.CPF.Contains(txtBoxPesquisaPessoa.Text)).ToList();

            if (dadosGrid.Count > 0)
                dataGridPessoa.ItemsSource = dadosGrid;
            else
                MessageBox.Show("Pessoa não encontrada!");
        }

        public void SalvarPessoa()
        {
            pessoa = new Pessoa
            {
                IdPessoa = IdPessoaLista,
                NomePessoa = nomePessoaBox.Text.ToUpper(),
                CPF = CPFBox.Text,
                Endereco = EnderecoBox.Text.ToUpper()
            };

            if (nomePessoaBox.Text != "" && CPFBox.Text != "")
            {
                if (Pessoa.ValidaCpf(pessoa.CPF))
                {
                    pessoas.Add(new Pessoa(IdPessoaLista, pessoa.NomePessoa, pessoa.CPF, pessoa.Endereco));

                    dataGridPessoa.Visibility = Visibility.Visible;
                    gridCadastrarPessoa.Visibility = Visibility.Collapsed;

                    MessageBox.Show("Cadastro efetuado com sucesso");

                    nomePessoaBox.Text = "";
                    CPFBox.Text = "";
                    EnderecoBox.Text = "";

                    gridPesquisaPessoa.Visibility = Visibility.Visible;

                    IdPessoaLista++;
                }
                else
                {
                    MessageBox.Show("CPF Inválido!");
                }
            }
            else
            {
                MessageBox.Show("Campos obrigatórios não preenchidos!!");
            }

        }


        public void SalvarProduto()
        {
            produto = new Produto();

            produto.NomeProduto = nomeProdutoBox.Text.ToUpper();
            produto.Codigo = codigoProdutoBox.Text;
            produto.Valor = double.Parse(valorProdutoBox.Text);


            if (nomeProdutoBox.Text != "" && codigoProdutoBox.Text != "" && valorProdutoBox.Text != "")
            {
                produtos.Add(new Produto(produtos.Count + 1, produto.NomeProduto, produto.Codigo, produto.Valor));

                gridCadastrarProduto.Visibility = Visibility.Collapsed;
                dataGridProduto.Visibility = Visibility.Visible;

                MessageBox.Show("Cadastro efetuado com sucesso");

                nomeProdutoBox.Text = "";
                codigoProdutoBox.Text = "";
                valorProdutoBox.Text = "";
            }

            else {
                MessageBox.Show("Campos obrigatórios não preenchidos!!");
            }

        }

        // private void BtnEditarPessoa_Click(object sender, RoutedEventArgs e)

        #endregion

        private void BtnCadastrarProduto_Click(object sender, RoutedEventArgs e)
        {
            dataGridPessoa.Visibility = Visibility.Collapsed;
            gridCadastrarProduto.Visibility = Visibility.Collapsed;
            TreeViewPedido.Visibility = Visibility.Collapsed;
            gridCadastrarProduto.Visibility = Visibility.Visible;

            dataGridProduto.Visibility = Visibility.Collapsed;

            idProdutoBox.Text = $"{produtos.Count + 1}";
        }

        private void BtnSalvarProduto_Click(object sender, RoutedEventArgs e)
        {
            SalvarProduto();
        }

        private void BtnCancelarProduto_Click(object sender, RoutedEventArgs e)
        {

        }
    }

}
