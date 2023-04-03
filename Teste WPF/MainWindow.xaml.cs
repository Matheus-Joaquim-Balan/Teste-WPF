using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Teste_WPF.ViewModels;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows.Data;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using System.Data;

namespace Teste_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Pessoa pessoa;
        private Produto produto;
        private ObservableCollection<Pessoa> pessoas;
        private ObservableCollection<Produto> produtos;

        public MainWindow()
        {
            InitializeComponent();
            pessoas = new ObservableCollection<Pessoa>();
            produtos = new ObservableCollection<Produto>();
            pessoa = new Pessoa();
            produto = new Produto();

            dataGridPessoa.ItemsSource = pessoas;
            dataGridProduto.ItemsSource = produtos;

            GerarTreeViewPedido tree = new GerarTreeViewPedido();         
            TreeViewItem level1_TVI = new TreeViewItem();            
            Pedido pedido = new Pedido();           
            level1_TVI.Header = "Pedido " + pedido.Id;           
            level1_TVI.Items.Add(tree.GerarTreePedidoLevel2(pedido));           
            TreeViewPedido.Items.Add(level1_TVI);                      
        }

        private void AbrirPessoa(object sender, RoutedEventArgs e)
        {
           
            this.dataGridPessoa.Visibility = Visibility.Visible;
            this.gridCadastrarProduto.Visibility = Visibility.Collapsed;
            this.gridCadastrarPessoa.Visibility = Visibility.Collapsed;
            this.TreeViewPedido.Visibility = Visibility.Collapsed;
            this.btnsPessoa.Visibility = Visibility.Visible;
            this.btnsPedido.Visibility = Visibility.Collapsed;
            this.btnsProduto.Visibility = Visibility.Collapsed;

            dataGridProduto.Visibility = Visibility.Collapsed;


            this.btnPessoa.Background = Brushes.LightGray;
            this.btnProduto.Background = Brushes.Transparent;
            this.btnPedido.Background = Brushes.Transparent;

            dataGridPessoa.ItemsSource = null;

            dataGridPessoa.ItemsSource = pessoas;
        }
 
        private void AbrirProduto(object sender, RoutedEventArgs e)
        {
            this.dataGridPessoa.Visibility = Visibility.Collapsed;
            this.gridCadastrarPessoa.Visibility = Visibility.Collapsed;
            this.gridCadastrarProduto.Visibility = Visibility.Collapsed;
            this.TreeViewPedido.Visibility = Visibility.Collapsed;
            this.btnsPessoa.Visibility = Visibility.Collapsed;
            this.btnsPedido.Visibility = Visibility.Collapsed;
            this.btnsProduto.Visibility = Visibility.Visible;

            dataGridProduto.Visibility = Visibility.Visible;

            this.btnPessoa.Background = Brushes.Transparent;
            this.btnProduto.Background = Brushes.LightGray;
            this.btnPedido.Background = Brushes.Transparent;            
        }

        private void AbrirPedido(object sender, RoutedEventArgs e)
        {
            this.dataGridPessoa.Visibility = Visibility.Collapsed;
            this.gridCadastrarPessoa.Visibility = Visibility.Collapsed;
            this.gridCadastrarProduto.Visibility = Visibility.Collapsed;
            this.TreeViewPedido.Visibility = Visibility.Visible;
            this.btnsPessoa.Visibility = Visibility.Collapsed;
            this.btnsPedido.Visibility = Visibility.Visible;
            this.btnsProduto.Visibility = Visibility.Collapsed;


            dataGridProduto.Visibility = Visibility.Collapsed;

            this.btnPessoa.Background = Brushes.Transparent;
            this.btnProduto.Background = Brushes.Transparent;
            this.btnPedido.Background = Brushes.LightGray;            
        }

        #region Botões Pessoa
        private void BtnCadastrarPessoa_Click(object sender, RoutedEventArgs e)
        {
            this.dataGridPessoa.Visibility = Visibility.Collapsed;
            this.gridCadastrarProduto.Visibility = Visibility.Collapsed;
            this.TreeViewPedido.Visibility = Visibility.Collapsed;
            this.gridCadastrarPessoa.Visibility = Visibility.Visible;

            idPessoaBox.Text = $"{pessoas.Count + 1}";
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


            this.dataGridPessoa.Visibility = Visibility.Visible;
            this.gridCadastrarPessoa.Visibility = Visibility.Collapsed;
        }

        private void BtnPesquisarNomeCPF_Click(object sender, RoutedEventArgs e)
        {
            var dadoPessoa = from p in pessoas
                             where txtBoxPesquisaPessoa.Text == p.CPF || txtBoxPesquisaPessoa.Text == p.NomePessoa
                             select p;



            if (dadoPessoa.Any())
            {
                dataGridPessoa.ItemsSource = null;
                dataGridPessoa.Items.Add(dadoPessoa);
            }
            else
            {
                MessageBox.Show("Pessoa não encontrada!!!");
            }
        }

        public void SalvarPessoa()
        {
            pessoa = new Pessoa();

            pessoa.NomePessoa = nomePessoaBox.Text.ToUpper();
            pessoa.CPF = CPFBox.Text;
            pessoa.Endereco = EnderecoBox.Text.ToUpper();

            if (nomePessoaBox.Text != "" && CPFBox.Text != "")
            {
                if (Pessoa.ValidaCpf(pessoa.CPF))
                {
                    pessoas.Add(new Pessoa(pessoas.Count + 1, pessoa.NomePessoa, pessoa.CPF, pessoa.Endereco));

                    this.dataGridPessoa.Visibility = Visibility.Visible;
                    this.gridCadastrarPessoa.Visibility = Visibility.Collapsed;

                    MessageBox.Show("Cadastro efetuado com sucesso");

                    nomePessoaBox.Text = "";
                    CPFBox.Text = "";
                    EnderecoBox.Text = "";
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

        //   private void BtnEditarPessoa_Click(object sender, RoutedEventArgs e)


        private void BtnExcluirPessoa_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = (DataRowView)dataGridPessoa.SelectedItem;

            row.Delete();
        }

        #endregion

        private void BtnCadastrarProduto_Click(object sender, RoutedEventArgs e)
        {
            this.dataGridPessoa.Visibility = Visibility.Collapsed;
            this.gridCadastrarProduto.Visibility = Visibility.Collapsed;
            this.TreeViewPedido.Visibility = Visibility.Collapsed;
            this.gridCadastrarProduto.Visibility = Visibility.Visible;

            dataGridProduto.Visibility = Visibility.Collapsed;

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
