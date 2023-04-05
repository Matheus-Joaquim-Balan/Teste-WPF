using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Teste_WPF.ViewModels;
using System.Linq;
using System.Collections.ObjectModel;
using System.Data;
using System;

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

            dataGridPessoa.SelectionMode = DataGridSelectionMode.Single;

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

            txtBoxPesquisaPessoa.Text = "";

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
            btnSalvarNovaPessoa.Visibility = Visibility.Visible;

            btnSalvarPessoaEdit.Visibility = Visibility.Collapsed;
            dataGridPessoa.Visibility = Visibility.Collapsed;
            gridCadastrarProduto.Visibility = Visibility.Collapsed;
            TreeViewPedido.Visibility = Visibility.Collapsed;
            gridPesquisaPessoa.Visibility = Visibility.Collapsed;

            if (IdPessoaLista < 1)
            {
                IdPessoaLista = 1;
                idPessoaBox.Text = $"{IdPessoaLista}";
            }
            else
                idPessoaBox.Text = $"{IdPessoaLista}";
        }

        private void BtnSalvarPessoa_Click(object sender, RoutedEventArgs e)
        {
            SalvarNovaPessoa();
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

        public void SalvarNovaPessoa()
        {        
            if (nomePessoaBox.Text != "" && CPFBox.Text != "")
            {
                if (Pessoa.ValidaCpf(CPFBox.Text))
                {
                    pessoas.Add(new Pessoa(IdPessoaLista, nomePessoaBox.Text.ToUpper(), CPFBox.Text, EnderecoBox.Text.ToUpper()));

                    dataGridPessoa.Visibility = Visibility.Visible;
                    gridPesquisaPessoa.Visibility = Visibility.Visible;

                    gridCadastrarPessoa.Visibility = Visibility.Collapsed;

                    MessageBox.Show("Cadastro efetuado com sucesso");

                    nomePessoaBox.Text = "";
                    CPFBox.Text = "";
                    EnderecoBox.Text = "";

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

        private void BtnEditarPessoa_Click(object sender, RoutedEventArgs e)
        {
            gridCadastrarPessoa.Visibility = Visibility.Visible;
            btnSalvarPessoaEdit.Visibility = Visibility.Visible;

            btnSalvarNovaPessoa.Visibility = Visibility.Collapsed;
            dataGridPessoa.Visibility = Visibility.Collapsed;
            gridCadastrarProduto.Visibility = Visibility.Collapsed;
            TreeViewPedido.Visibility = Visibility.Collapsed;
            gridPesquisaPessoa.Visibility = Visibility.Collapsed;

            var data = dataGridPessoa.SelectedIndex;

            if (data != -1) {
                idPessoaBox.Text = Convert.ToString(pessoas[data].IdPessoa);
                nomePessoaBox.Text = pessoas[data].NomePessoa;
                CPFBox.Text = pessoas[data].CPF;
                EnderecoBox.Text = pessoas[data].Endereco;
            }
        }

        private void btnSalvarPessoaEdit_Click(object sender, RoutedEventArgs e)
        {
            SalvarPessoaEditada();
        }

        public void SalvarPessoaEditada()
        {
            if (nomePessoaBox.Text != "" && CPFBox.Text != "")
            {
                if (Pessoa.ValidaCpf(CPFBox.Text))
                {
                    int idEdit = Convert.ToInt32(idPessoaBox.Text);
                 
                    pessoas[idEdit - 1].NomePessoa = nomePessoaBox.Text.ToUpper();
                    pessoas[idEdit - 1].CPF = CPFBox.Text;
                    pessoas[idEdit - 1].Endereco = EnderecoBox.Text.ToUpper();

                    dataGridPessoa.Visibility = Visibility.Visible;
                    gridPesquisaPessoa.Visibility = Visibility.Visible;

                    gridCadastrarPessoa.Visibility = Visibility.Collapsed;

                    MessageBox.Show($"Pessoa: {nomePessoaBox.Text} editada com sucesso");

                    idPessoaBox.Text = "";
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
        
        #endregion

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

            idProdutoBox.Text = $"{produtos.Count + 1}";
        }

        public void BtnSalvarProduto_Click(object sender, RoutedEventArgs e)
        {
            SalvarProduto();
        }

        public void BtnCancelarProduto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnPesquisarProduto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEditarProduto_Click(object sender, RoutedEventArgs e)
        {

        }

    }

}
