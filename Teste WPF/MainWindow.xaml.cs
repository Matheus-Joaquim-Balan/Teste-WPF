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
        private Pedido pedido;
        public int IdPedidoLista { get; set; }
        private ObservableCollection<Pessoa> pessoas;
        private ObservableCollection<Produto> produtos;
        private ObservableCollection<Pedido> pedidos;

        public MainWindow()
        {
            InitializeComponent();
            pessoas = new ObservableCollection<Pessoa>();
            produtos = new ObservableCollection<Produto>();
            pedidos = new ObservableCollection<Pedido>();
            pessoa = new Pessoa();
            produto = new Produto();
            pedido = new Pedido();

            dataGridPessoa.SelectionMode = DataGridSelectionMode.Single;

        }

        private void AbrirPessoa(object sender, RoutedEventArgs e)
        {

            dataGridPessoa.Visibility = Visibility.Visible;
            btnCadastrarPessoa.Visibility = Visibility.Visible;
            gridPesquisaPessoa.Visibility = Visibility.Visible;

            gridPedido.Visibility = Visibility.Collapsed;
            gridCadastrarProduto.Visibility = Visibility.Collapsed;
            gridCadastrarPessoa.Visibility = Visibility.Collapsed;
            btnCadastrarProduto.Visibility = Visibility.Collapsed;
            dataGridProduto.Visibility = Visibility.Collapsed;
            gridPesquisaProduto.Visibility = Visibility.Collapsed;

            txtBoxPesquisaPessoa.Text = "";

            btnPessoa.Background = Brushes.LightGray;
            btnProduto.Background = Brushes.Transparent;

            dataGridPessoa.ItemsSource = pessoas;
        }

        private void AbrirProduto(object sender, RoutedEventArgs e)
        {
            btnCadastrarProduto.Visibility = Visibility.Visible;
            dataGridProduto.Visibility = Visibility.Visible;

            gridPedido.Visibility = Visibility.Collapsed;
            dataGridPessoa.Visibility = Visibility.Collapsed;
            gridCadastrarPessoa.Visibility = Visibility.Collapsed;
            gridCadastrarProduto.Visibility = Visibility.Collapsed;
            btnCadastrarPessoa.Visibility = Visibility.Collapsed;
            gridPesquisaPessoa.Visibility = Visibility.Collapsed;
            gridPesquisaProduto.Visibility = Visibility.Visible;

            btnPessoa.Background = Brushes.Transparent;
            btnProduto.Background = Brushes.LightGray;

            dataGridProduto.ItemsSource = produtos;

            if(dataGridProduto.DataContext == null)
            {
                minimoTB.Text = "Mínimo";
                maximoTB.Text = "Máximo";
            }
            else 
            {
                maximoTB.Text = Convert.ToString(produtos.Max(p => p.Valor));
                minimoTB.Text = Convert.ToString(produtos.Min(p => p.Valor));
            }
        }

    /*    private void AbrirPedido(object sender, RoutedEventArgs e)
        {
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
        }*/

        #region Botões Pessoa
        private void BtnCadastrarPessoa_Click(object sender, RoutedEventArgs e)
        {
            gridCadastrarPessoa.Visibility = Visibility.Visible;
            btnSalvarNovaPessoa.Visibility = Visibility.Visible;

            btnSalvarPessoaEdit.Visibility = Visibility.Collapsed;
            dataGridPessoa.Visibility = Visibility.Collapsed;
            gridCadastrarProduto.Visibility = Visibility.Collapsed;
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
                    int idText = Convert.ToInt32(idPessoaBox.Text);
                    int indexList = pessoas.IndexOf(pessoas.Where(p => p.IdPessoa == idText).FirstOrDefault());

                    pessoas[indexList].NomePessoa = nomePessoaBox.Text.ToUpper();
                    pessoas[indexList].CPF = CPFBox.Text;
                    pessoas[indexList].Endereco = EnderecoBox.Text.ToUpper();

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

        private void ExcluirPessoa_Click(object sender, RoutedEventArgs e)
        {
            dynamic data = dataGridPessoa.SelectedItem;
            pessoas.Remove(data);
        }

        #endregion

        #region Botões Produto

        public void SalvarProduto()
        {
            produto = new Produto();

            if (nomeProdutoBox.Text != "" && codigoProdutoBox.Text != "" && valorProdutoBox.Text != "")
            {
                produtos.Add(new Produto(IdProdutoLista, nomeProdutoBox.Text.ToUpper(), codigoProdutoBox.Text, double.Parse(valorProdutoBox.Text)));

                gridCadastrarProduto.Visibility = Visibility.Collapsed;
                dataGridProduto.Visibility = Visibility.Visible;
                gridPesquisaProduto.Visibility = Visibility.Visible;

                MessageBox.Show("Cadastro efetuado com sucesso");

                IdProdutoLista++;
                nomeProdutoBox.Text = "";
                codigoProdutoBox.Text = "";
                valorProdutoBox.Text = "";
            }
            else {
                MessageBox.Show("Campos obrigatórios não preenchidos!!");
            }
        }

        public void SalvarProdutoEdit()
        {

            if (nomeProdutoBox.Text != "" && codigoProdutoBox.Text != "" && valorProdutoBox.Text != "")
            {
                
                    int idText = Convert.ToInt32(idProdutoBox.Text);
                    int indexList = produtos.IndexOf(produtos.Where(p => p.IdProduto == idText).FirstOrDefault());

                    produtos[indexList].NomeProduto = nomeProdutoBox.Text.ToUpper();
                    produtos[indexList].Codigo = codigoProdutoBox.Text;
                    produtos[indexList].Valor = double.Parse(valorProdutoBox.Text);

                    dataGridProduto.Visibility = Visibility.Visible;
                    gridPesquisaProduto.Visibility = Visibility.Visible;
                    
                    gridCadastrarProduto.Visibility = Visibility.Collapsed;

                    dataGridProduto.Items.Refresh();
                    MessageBox.Show($"Produto: {nomeProdutoBox.Text} editado com sucesso");

                    idProdutoBox.Text = "";
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
            gridCadastrarProduto.Visibility = Visibility.Visible;
            btnSalvarProduto.Visibility = Visibility.Visible;
            btnSalvarProdutoEdit.Visibility = Visibility.Collapsed;
            gridPesquisaProduto.Visibility = Visibility.Collapsed;

            dataGridProduto.Visibility = Visibility.Collapsed;

            if (IdProdutoLista < 1)
                IdProdutoLista = 1;

            idProdutoBox.Text = $"{IdProdutoLista}";
        }

        private void BtnSalvarProduto_Click(object sender, RoutedEventArgs e)
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
            var dadosGrid = produtos.Where(p => p.NomeProduto.Contains(txtBoxPesquisaProduto.Text) || p.Codigo.Contains(txtBoxPesquisaProduto.Text)).ToList();

            if (dadosGrid.Count > 0)
                dataGridProduto.ItemsSource = dadosGrid;
            else
                MessageBox.Show("Produto não encontrado!");


            var dadosValor = produtos.Where(p => p.Valor > double.Parse(minimoTB.Text) && p.Valor <= double.Parse(maximoTB.Text)).ToList();

            if (dadosValor.Count > 0)
            {
                dataGridProduto.ItemsSource = dadosValor;
            }
        }

        private void EditarProduto_Click(object sender, RoutedEventArgs e)
        {
            dataGridPessoa.Visibility = Visibility.Collapsed;
            gridCadastrarProduto.Visibility = Visibility.Collapsed;
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

        private void ExcluirProduto_Click(object sender, RoutedEventArgs e)
        {
            dynamic data = dataGridProduto.SelectedItem;
            produtos.Remove(data);
        }

        #endregion

        private void BtnDetalhesPedido_Click(object sender, RoutedEventArgs e)
        {
            dynamic data = dataGridPessoa.SelectedItem;
            string indexData = data.NomePessoa;
            int indexList = pedidos.IndexOf(pedidos.Where(p => p.Pessoas.NomePessoa == indexData).FirstOrDefault());

            if (indexList != -1)
            {
                gridPedido.Visibility = Visibility.Visible;

                dataGridPessoa.Visibility = Visibility.Collapsed;
                dataGridProduto.Visibility = Visibility.Collapsed;

                idPedidoBox.Text = pedidos[indexList].Id.ToString();
                nomePedidoPessoaBox.Text = pedidos[indexList].Pessoas.NomePessoa;
                produtosPedidoBox.Text = pedidos[indexList].Produtos.NomeProduto;
                valorTotalPedidoBox.Text = Convert.ToString(pedidos[indexList].Produtos.Valor * pedido.QntProduto);
                DataPedidoBox.Text = pedidos[indexList].DataVenda;
                FormaPagPedidoBox.Text = Convert.ToString(pedidos[indexList].FormaPagamento);
                StatusPedidoBox.Text = Convert.ToString(pedidos[indexList].Status);
            }
            else
            {
               MessageBox.Show("Nenhum pedido encontrado!!");                                         
            }
        }
    }
}
