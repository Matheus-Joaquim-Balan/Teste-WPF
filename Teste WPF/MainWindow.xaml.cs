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
        public int IdPessoaLista { get; set; }
        private Produto produto;
        public int IdProdutoLista { get; set; }
        private ObservableCollection<Pessoa> pessoas;
        private ObservableCollection<Produto> produtos;

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
            dynamic data = dataGridPessoa.SelectedItem;
            int indexData = data.IdPessoa;
            int indexList = pessoas.IndexOf(pessoas.Where(p => p.IdPessoa == indexData).FirstOrDefault()); 

            if (indexList != -1)
            {
                gridCadastrarPessoa.Visibility = Visibility.Visible;
                btnSalvarPessoaEdit.Visibility = Visibility.Visible;

                btnSalvarNovaPessoa.Visibility = Visibility.Collapsed;
                dataGridPessoa.Visibility = Visibility.Collapsed;
                gridCadastrarProduto.Visibility = Visibility.Collapsed;
                TreeViewPedido.Visibility = Visibility.Collapsed;
                gridPesquisaPessoa.Visibility = Visibility.Collapsed;

                idPessoaBox.Text = Convert.ToString(pessoas[indexList].IdPessoa);
                nomePessoaBox.Text = pessoas[indexList].NomePessoa;
                CPFBox.Text = pessoas[indexList].CPF;
                EnderecoBox.Text = pessoas[indexList].Endereco;
            }
            else
            {
                MessageBox.Show("Erro ao carregar os dados");
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
                    int idList = 0;
                    int count = 0;

                    foreach (var p in pessoas)
                    {
                        if (p.IdPessoa == Convert.ToInt32(idPessoaBox.Text))
                        {
                            idList = count;
                            break;
                        }
                        count++;
                    }

                    pessoas[idList].NomePessoa = nomePessoaBox.Text.ToUpper();
                    pessoas[idList].CPF = CPFBox.Text;
                    pessoas[idList].Endereco = EnderecoBox.Text.ToUpper();

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

            if (!string.IsNullOrEmpty(valorProdutoBox.Text))
            {
                produto.Valor = double.Parse(valorProdutoBox.Text);
            }

            if (nomeProdutoBox.Text != "" && codigoProdutoBox.Text != "" && valorProdutoBox.Text != "")
            {
                produtos.Add(new Produto(IdProdutoLista, nomeProdutoBox.Text.ToUpper(), codigoProdutoBox.Text, produto.Valor));

                gridCadastrarProduto.Visibility = Visibility.Collapsed;
                dataGridProduto.Visibility = Visibility.Visible;

                MessageBox.Show("Cadastro efetuado com sucesso");

                IdProdutoLista++;
                nomeProdutoBox.Text = "";
                codigoProdutoBox.Text = "";
                valorProdutoBox.Text = "";
            }
            else
            {
                MessageBox.Show("Campos obrigatórios não preenchidos!!");
            }

        }

        public void SalvarProdutoEdit()
        {
            if (nomeProdutoBox.Text != "" && codigoProdutoBox.Text != "" && valorProdutoBox.Text != "")
            {

                int idEdit = Convert.ToInt32(idProdutoBox.Text);

                produtos[idEdit - 1].NomeProduto = nomeProdutoBox.Text.ToUpper();
                produtos[idEdit - 1].Codigo = codigoProdutoBox.Text;

                if (!string.IsNullOrEmpty(valorProdutoBox.Text))
                {
                    produtos[idEdit - 1].Valor = double.Parse(valorProdutoBox.Text);
                }

                gridCadastrarProduto.Visibility = Visibility.Collapsed;
                dataGridProduto.Visibility = Visibility.Visible;
                dataGridProduto.Items.Refresh();

                MessageBox.Show("Alteração efetuada com sucesso");

                idPessoaBox.Text = "";
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

            if (IdProdutoLista < 1)
                IdProdutoLista = 1;

            idProdutoBox.Text = $"{IdProdutoLista}";
        }

        public void BtnSalvarProduto_Click(object sender, RoutedEventArgs e)
        {
            SalvarProduto();
        }

        public void BtnCancelarProduto_Click(object sender, RoutedEventArgs e)
        {
            nomeProdutoBox.Text = "";
            codigoProdutoBox.Text = "";
            valorProdutoBox.Text = "";

            dataGridProduto.Visibility = Visibility.Visible;
            gridCadastrarProduto.Visibility = Visibility.Collapsed;
            gridPesquisaProduto.Visibility = Visibility.Visible;
        }

        private void BtnPesquisarProduto_Click(object sender, RoutedEventArgs e)
        {
            dataGridProduto.ItemsSource = produtos.Where(p => p.NomeProduto.Contains(txtBoxPesquisaProduto.Text) || p.Codigo.Contains(txtBoxPesquisaProduto.Text)).ToList();
        }

        private void EditarProduto_Click(object sender, RoutedEventArgs e)
        {
            dataGridPessoa.Visibility = Visibility.Collapsed;
            gridCadastrarProduto.Visibility = Visibility.Collapsed;
            TreeViewPedido.Visibility = Visibility.Collapsed;
            gridCadastrarProduto.Visibility = Visibility.Visible;
            dataGridProduto.Visibility = Visibility.Collapsed;
            gridPesquisaProduto.Visibility = Visibility.Collapsed;
            btnSalvarProduto.Visibility = Visibility.Collapsed;
            btnSalvarProdutoEdit.Visibility = Visibility.Visible;

            var data = dataGridProduto.SelectedIndex;

            if (data != -1)
            {

                idProdutoBox.Text = produtos[data].IdProduto.ToString();
                nomeProdutoBox.Text = produtos[data].NomeProduto;
                codigoProdutoBox.Text = produtos[data].Codigo;
                valorProdutoBox.Text = produtos[data].Valor.ToString();
            }
        }

        private void BtnSalvarProdutoEdit_Click(object sender, RoutedEventArgs e)
        {
            SalvarProdutoEdit();
        }

    }

}
