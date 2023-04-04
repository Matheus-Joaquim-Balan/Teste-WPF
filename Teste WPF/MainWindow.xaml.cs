using System.Collections.Generic;
using System.Globalization;
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
using System;

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

            GerarTreeViewPedido tree = new GerarTreeViewPedido();         
            TreeViewItem level1_TVI = new TreeViewItem();            
            Pedido pedido = new Pedido();           
            level1_TVI.Header = "Pedido " + pedido.Id;           
            level1_TVI.Items.Add(tree.GerarTreePedidoLevel2(pedido));           
            TreeViewPedido.Items.Add(level1_TVI);                      
        }

        #region Abrir Telas

        private void AbrirPessoa(object sender, RoutedEventArgs e)
        {
           
            dataGridPessoa.Visibility = Visibility.Visible;
            gridCadastrarProduto.Visibility = Visibility.Collapsed;
            gridCadastrarPessoa.Visibility = Visibility.Collapsed;
            TreeViewPedido.Visibility = Visibility.Collapsed;
            btnsPessoa.Visibility = Visibility.Visible;
            btnsPedido.Visibility = Visibility.Collapsed;
            btnsProduto.Visibility = Visibility.Collapsed;
            gridPesquisaPessoa.Visibility = Visibility.Visible;
            dataGridProduto.Visibility = Visibility.Collapsed;
            gridPesquisaProduto.Visibility = Visibility.Collapsed;

            txtBoxPesquisaProduto.Text = "";

            btnPessoa.Background = Brushes.LightGray;
            btnProduto.Background = Brushes.Transparent;
            btnPedido.Background = Brushes.Transparent;

            dataGridPessoa.ItemsSource = pessoas;
        }

        private void AbrirProduto(object sender, RoutedEventArgs e)
        {
            dataGridPessoa.Visibility = Visibility.Collapsed;
            gridCadastrarPessoa.Visibility = Visibility.Collapsed;
            gridCadastrarProduto.Visibility = Visibility.Collapsed;
            TreeViewPedido.Visibility = Visibility.Collapsed;
            btnsPessoa.Visibility = Visibility.Collapsed;
            btnsPedido.Visibility = Visibility.Collapsed;
            btnsProduto.Visibility = Visibility.Visible;
            gridPesquisaPessoa.Visibility = Visibility.Collapsed;
            gridPesquisaProduto.Visibility = Visibility.Visible;
            dataGridProduto.Visibility = Visibility.Visible;

            txtBoxPesquisaPessoa.Text = "";

            btnPessoa.Background = Brushes.Transparent;
            btnProduto.Background = Brushes.LightGray;
            btnPedido.Background = Brushes.Transparent;

            dataGridProduto.ItemsSource = produtos;
        }

        private void AbrirPedido(object sender, RoutedEventArgs e)
        {
            dataGridPessoa.Visibility = Visibility.Collapsed;
            gridCadastrarPessoa.Visibility = Visibility.Collapsed;
            gridCadastrarProduto.Visibility = Visibility.Collapsed;
            TreeViewPedido.Visibility = Visibility.Visible;
            btnsPessoa.Visibility = Visibility.Collapsed;
            btnsPedido.Visibility = Visibility.Visible;
            btnsProduto.Visibility = Visibility.Collapsed;
            gridPesquisaPessoa.Visibility = Visibility.Collapsed;
            gridPesquisaProduto.Visibility = Visibility.Collapsed;
            dataGridProduto.Visibility = Visibility.Collapsed;

            txtBoxPesquisaProduto.Text = "";
            txtBoxPesquisaPessoa.Text = "";

            btnPessoa.Background = Brushes.Transparent;
            btnProduto.Background = Brushes.Transparent;
            btnPedido.Background = Brushes.LightGray;            
        }

        #endregion

        #region Botões Pessoa
        private void BtnCadastrarPessoa_Click(object sender, RoutedEventArgs e)
        {
            dataGridPessoa.Visibility = Visibility.Collapsed;
            gridCadastrarProduto.Visibility = Visibility.Collapsed;
            TreeViewPedido.Visibility = Visibility.Collapsed;
            gridCadastrarPessoa.Visibility = Visibility.Visible;
            gridPesquisaPessoa.Visibility = Visibility.Collapsed;

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

            dataGridPessoa.Visibility = Visibility.Visible;
            gridCadastrarPessoa.Visibility = Visibility.Collapsed;
            gridPesquisaPessoa.Visibility = Visibility.Visible;
        }

        private void BtnPesquisarNomeCPF_Click(object sender, RoutedEventArgs e)
        {          
            dataGridPessoa.ItemsSource = pessoas.Where(g => g.NomePessoa.Contains(txtBoxPesquisaPessoa.Text) || g.CPF.Contains(txtBoxPesquisaPessoa.Text)).ToList();  
        }

        public void SalvarPessoa()
        {
            pessoa = new Pessoa
            {
                NomePessoa = nomePessoaBox.Text.ToUpper(),
                CPF = CPFBox.Text,
                Endereco = EnderecoBox.Text.ToUpper()
            };

            if (nomePessoaBox.Text != "" && CPFBox.Text != "")
            {
                if (Pessoa.ValidaCpf(pessoa.CPF))
                {
                    pessoas.Add(new Pessoa(pessoas.Count + 1, pessoa.NomePessoa, pessoa.CPF, pessoa.Endereco));

                    dataGridPessoa.Visibility = Visibility.Visible;
                    gridCadastrarPessoa.Visibility = Visibility.Collapsed;
                    gridPesquisaPessoa.Visibility = Visibility.Visible;

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

        //   private void BtnEditarPessoa_Click(object sender, RoutedEventArgs e)

        private void BtnExcluirPessoa_Click(object sender, RoutedEventArgs e)
        {  
          //  dataGridPessoa.ItemsSource = delete ;
        }

        #endregion

        #region Botões Produtos

        public void SalvarProduto()
        {
            produto = new Produto();

            produto.NomeProduto = nomeProdutoBox.Text.ToUpper();
            produto.Codigo = codigoProdutoBox.Text;

            if (!string.IsNullOrEmpty(valorProdutoBox.Text))
            {
                produto.Valor = double.Parse(valorProdutoBox.Text);
            }

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

            else
            {
                MessageBox.Show("Campos obrigatórios não preenchidos!!");
            }

        }

        private void BtnCadastrarProduto_Click(object sender, RoutedEventArgs e)
        {
            dataGridPessoa.Visibility = Visibility.Collapsed;
            gridCadastrarProduto.Visibility = Visibility.Collapsed;
            TreeViewPedido.Visibility = Visibility.Collapsed;
            gridCadastrarProduto.Visibility = Visibility.Visible;
            dataGridProduto.Visibility = Visibility.Collapsed;
            gridPesquisaProduto.Visibility = Visibility.Collapsed;

            idProdutoBox.Text = $"{produtos.Count + 1}";
        }

        private void BtnPesquisarProduto_Click(object sender, RoutedEventArgs e)
        {
            dataGridProduto.ItemsSource = produtos.Where(p => p.NomeProduto.Contains(txtBoxPesquisaProduto.Text) || p.Codigo.Contains(txtBoxPesquisaProduto.Text)).ToList();
        }

        private void BtnSalvarProduto_Click(object sender, RoutedEventArgs e)
        {
            SalvarProduto();
        }

        private void BtnCancelarProduto_Click(object sender, RoutedEventArgs e)
        {
            nomeProdutoBox.Text = "";
            codigoProdutoBox.Text = "";
            valorProdutoBox.Text = "";

            dataGridProduto.Visibility = Visibility.Visible;
            gridCadastrarProduto.Visibility = Visibility.Collapsed;
            gridPesquisaProduto.Visibility = Visibility.Visible;
        }

        private void BtnEditarProduto_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridProduto.HasItems)
            {
                dataGridPessoa.Visibility = Visibility.Collapsed;
                gridCadastrarProduto.Visibility = Visibility.Collapsed;
                TreeViewPedido.Visibility = Visibility.Collapsed;
                gridCadastrarProduto.Visibility = Visibility.Visible;
                dataGridProduto.Visibility = Visibility.Collapsed;
                gridPesquisaProduto.Visibility = Visibility.Collapsed;


            }
            else
            {
                MessageBox.Show("Nenhum cadastro para alterar");
            }
        }
    }
        #endregion
}
