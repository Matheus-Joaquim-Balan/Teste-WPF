using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Linq;
using System.Collections.ObjectModel;
using System.Data;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using Teste_WPF.Models;
using Teste_WPF.ViewModel;

namespace Teste_WPF
{

    public partial class MainWindow : Window
    {
        private int IdPessoaLista { get; set; }
        private Produto produto;
        private int IdProdutoLista { get; set; }
        private int IdPedidoLista { get; set; }
        private ObservableCollection<Pessoa> pessoas;
        private ObservableCollection<Produto> produtos;
        private ObservableCollection<Pedido> pedidos;
        private List<Produto> produtosPedido;

        public MainWindow()
        {
            //InitializeComponent();
            //pessoas = new ObservableCollection<Pessoa>();
            //produtos = new ObservableCollection<Produto>();
            //pedidos = new ObservableCollection<Pedido>();
            //produtosPedido = new List<Produto>();
            //produto = new Produto();

            //LerXmlProduto("C:\\Produtos.xml");
            //dataGridProduto.ItemsSource = produtos;
            //produtosPedListBox.ItemsSource = produtos;

            //LerXmlPessoa("C:\\Pessoas.xml");
            //dataGridPessoa.ItemsSource = pessoas;

            //pedidos = LerXmlPedido(); 
            //dataGridPedidos.ItemsSource = pedidos;
            //if(pedidos.Count() > 0)
            //    IdPedidoLista = pedidos.Last().UltimoId;

            //dataGridPessoa.SelectionMode = DataGridSelectionMode.Single;
        }

        private void AbrirPessoa(object sender, RoutedEventArgs e)
        {
            DataContext = new PessoaViewModel(); 
        }

        private void AbrirProduto(object sender, RoutedEventArgs e)
        {
            //btnCadastrarProduto.Visibility = Visibility.Visible;
            //dataGridProduto.Visibility = Visibility.Visible;
            //gridPesquisaProduto.Visibility = Visibility.Visible;

            //gridPesquisaStatus.Visibility = Visibility.Collapsed;
            //dataGridPedidoExpandido.Visibility = Visibility.Collapsed;
            //dataGridPedidos.Visibility = Visibility.Collapsed;
            //gridPedido.Visibility = Visibility.Collapsed;
            ////dataGridPessoa.Visibility = Visibility.Collapsed;
            ////gridCadastrarPessoa.Visibility = Visibility.Collapsed;
            ////gridCadastrarProduto.Visibility = Visibility.Collapsed;
            ////btnCadastrarPessoa.Visibility = Visibility.Collapsed;
            ////gridPesquisaPessoa.Visibility = Visibility.Collapsed;

            //btnPessoa.Background = Brushes.Transparent;
            //btnProduto.Background = Brushes.LightGray;

            //if (dataGridProduto.DataContext == null)
            //{
            //    minimoTB.Text = "0";
            //    maximoTB.Text = "9999999";
            //}
            //else
            //{
            //    maximoTB.Text = Convert.ToString(produtos.Max(p => p.Valor));
            //    minimoTB.Text = Convert.ToString(produtos.Min(p => p.Valor));
            //}
        }

        private void AceitarApenasNumeros(TextBox textBox)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox.Text, "[^0-9]"))
            {
                MessageBox.Show("Digite apenas números");
                textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1);
            }
        }

        #region Botões Pessoa
        private void BtnCadastrarPessoa_Click(object sender, RoutedEventArgs e)
        {
            //gridCadastrarPessoa.Visibility = Visibility.Visible;
            //btnSalvarNovaPessoa.Visibility = Visibility.Visible;

            //btnSalvarPessoaEdit.Visibility = Visibility.Collapsed;
            //dataGridPessoa.Visibility = Visibility.Collapsed;
            //gridCadastrarProduto.Visibility = Visibility.Collapsed;
            //gridPesquisaPessoa.Visibility = Visibility.Collapsed;

            if (IdPessoaLista < 1)
                IdPessoaLista = 1;

          //  idPessoaBox.Text = $"{IdPessoaLista}";
        }

        private void BtnSalvarPessoa_Click(object sender, RoutedEventArgs e)
        {
            SalvarNovaPessoa();
        }

        private void BtnCancelarPessoa_Click(object sender, RoutedEventArgs e)
        {
            //nomePessoaBox.Text = "";
            //CPFBox.Text = "";
            //EnderecoBox.Text = "";

            //dataGridPessoa.Visibility = Visibility.Visible;
            //gridCadastrarPessoa.Visibility = Visibility.Collapsed;
            //gridPesquisaPessoa.Visibility = Visibility.Visible;

        }

        private void BtnPesquisarNomeCPF_Click(object sender, RoutedEventArgs e)
        {
            //var dadosGrid = pessoas.Where(g => g.NomePessoa.Contains(txtBoxPesquisaPessoa.Text) || g.CPF.Contains(txtBoxPesquisaPessoa.Text)).ToList();

            //if (dadosGrid.Count > 0 && txtBoxPesquisaPessoa.Text != "")
            //    dataGridPessoa.ItemsSource = dadosGrid;
            //else
            //    MessageBox.Show("Pessoa não encontrada!");

            //txtBoxPesquisaPessoa.Text = "";
        }

        private void CPFBox__TextChanged(object sender, TextChangedEventArgs e)
        {
           // AceitarApenasNumeros(CPFBox);
        }

        public void SalvarNovaPessoa()
        {
            //if (nomePessoaBox.Text != "" && CPFBox.Text != "")
            //{
            //    if (Pessoa.ValidaCpf(CPFBox.Text))
            //    {
            //        pessoas.Add(new Pessoa(IdPessoaLista, nomePessoaBox.Text.ToUpper(), CPFBox.Text, EnderecoBox.Text.ToUpper()));

            //        dataGridPessoa.Visibility = Visibility.Visible;
            //        gridPesquisaPessoa.Visibility = Visibility.Visible;

            //        gridCadastrarPessoa.Visibility = Visibility.Collapsed;

            //        MessageBox.Show("Cadastro efetuado com sucesso");

            //        nomePessoaBox.Text = "";
            //        CPFBox.Text = "";
            //        EnderecoBox.Text = "";

            //        IdPessoaLista++;

            //        ExportarXmlPessoa("C:\\Pessoas.xml");
            //    }
            //    else
            //    {
            //        MessageBox.Show("CPF Inválido!");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Campos obrigatórios não preenchidos!!");
            //}

        }

        private void BtnEditarPessoa_Click(object sender, RoutedEventArgs e)
        {
            //dynamic data = dataGridPessoa.SelectedItem;
            //int indexData = data.IdPessoa;
            //int indexList = pessoas.IndexOf(pessoas.Where(p => p.IdPessoa == indexData).FirstOrDefault());

            //if (indexList != -1)
            //{
            //    gridCadastrarPessoa.Visibility = Visibility.Visible;
            //    btnSalvarPessoaEdit.Visibility = Visibility.Visible;

            //    btnSalvarNovaPessoa.Visibility = Visibility.Collapsed;
            //    dataGridPessoa.Visibility = Visibility.Collapsed;
            //    gridCadastrarProduto.Visibility = Visibility.Collapsed;
            //    gridPesquisaPessoa.Visibility = Visibility.Collapsed;

            //    idPessoaBox.Text = Convert.ToString(pessoas[indexList].IdPessoa);
            //    nomePessoaBox.Text = pessoas[indexList].NomePessoa;
            //    CPFBox.Text = pessoas[indexList].CPF;
            //    EnderecoBox.Text = pessoas[indexList].Endereco;
            //}
            //else
            //{
            //    MessageBox.Show("Erro ao carregar os dados");
            //}
        }

        //private void btnSalvarPessoaEdit_Click(object sender, RoutedEventArgs e)
        //{
        //    SalvarPessoaEditada();
        //}

        //public void SalvarPessoaEditada()
        //{
        //    if (nomePessoaBox.Text != "" && CPFBox.Text != "")
        //    {
        //        if (Pessoa.ValidaCpf(CPFBox.Text))
        //        {
        //            int idText = Convert.ToInt32(idPessoaBox.Text);
        //            int indexList = pessoas.IndexOf(pessoas.Where(p => p.IdPessoa == idText).FirstOrDefault());

        //            pessoas[indexList].NomePessoa = nomePessoaBox.Text.ToUpper();
        //            pessoas[indexList].CPF = CPFBox.Text;
        //            pessoas[indexList].Endereco = EnderecoBox.Text.ToUpper();

        //            dataGridPessoa.Visibility = Visibility.Visible;
        //            gridPesquisaPessoa.Visibility = Visibility.Visible;

        //            gridCadastrarPessoa.Visibility = Visibility.Collapsed;

        //            MessageBox.Show($"Pessoa: {nomePessoaBox.Text} editada com sucesso");

        //            idPessoaBox.Text = "";
        //            nomePessoaBox.Text = "";
        //            CPFBox.Text = "";
        //            EnderecoBox.Text = "";

        //            ExportarXmlPessoa("C:\\Pessoas.xml");

        //        }
        //        else
        //        {
        //            MessageBox.Show("CPF Inválido!");
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Campos obrigatórios não preenchidos!!");
        //    }
        //}

        //private void ExcluirPessoa_Click(object sender, RoutedEventArgs e)
        //{
        //    //dynamic data = dataGridPessoa.SelectedItem;
        //    //pessoas.Remove(data);
        //    //ExportarXmlPessoa("C:\\Pessoas.xml");

        //}

        #endregion

        #region Botões Produto

        //public void SalvarProduto()
        //{
        //    produto = new Produto();

        //    if (nomeProdutoBox.Text != "" && codigoProdutoBox.Text != "" && valorProdutoBox.Text != "")
        //    {
        //        produtos.Add(new Produto(IdProdutoLista, nomeProdutoBox.Text.ToUpper(), codigoProdutoBox.Text, double.Parse(valorProdutoBox.Text.Replace('.', ','))));

        //        gridCadastrarProduto.Visibility = Visibility.Collapsed;
        //        dataGridProduto.Visibility = Visibility.Visible;
        //        gridPesquisaProduto.Visibility = Visibility.Visible;


        //        MessageBox.Show("Cadastro efetuado com sucesso");

        //        IdProdutoLista++;
        //        nomeProdutoBox.Text = "";
        //        codigoProdutoBox.Text = "";
        //        valorProdutoBox.Text = "";

        //        ExportarXmlProduto("C:\\Produtos.xml");

        //    }
        //    else
        //    {
        //        MessageBox.Show("Campos obrigatórios não preenchidos!!");
        //    }
        //}



        //public void SalvarProdutoEdit()
        //{

        //    if (nomeProdutoBox.Text != "" && codigoProdutoBox.Text != "" && valorProdutoBox.Text != "")
        //    {

        //        int idText = Convert.ToInt32(idProdutoBox.Text);
        //        int indexList = produtos.IndexOf(produtos.Where(p => p.IdProduto == idText).FirstOrDefault());


        //        produtos[indexList].NomeProduto = nomeProdutoBox.Text.ToUpper();
        //        produtos[indexList].Codigo = codigoProdutoBox.Text;

        //        if (!string.IsNullOrEmpty(valorProdutoBox.Text))
        //        {
        //            produtos[indexList].Valor = double.Parse(valorProdutoBox.Text);
        //        }

        //        dataGridProduto.Visibility = Visibility.Visible;
        //        gridPesquisaProduto.Visibility = Visibility.Visible;

        //        gridCadastrarProduto.Visibility = Visibility.Collapsed;

        //        dataGridProduto.Items.Refresh();
        //        MessageBox.Show($"Produto: {nomeProdutoBox.Text} editado com sucesso");

        //        idProdutoBox.Text = "";
        //        nomeProdutoBox.Text = "";
        //        codigoProdutoBox.Text = "";
        //        valorProdutoBox.Text = "";

        //        ExportarXmlProduto("C:\\Produtos.xml");

        //    }
        //    else
        //    {
        //        MessageBox.Show("Campos obrigatórios não preenchidos!!");
        //    }
        //}

        //private void BtnCadastrarProduto_Click(object sender, RoutedEventArgs e)
        //{
        //    //dataGridPessoa.Visibility = Visibility.Collapsed;
        //    gridCadastrarProduto.Visibility = Visibility.Collapsed;
        //    gridCadastrarProduto.Visibility = Visibility.Visible;
        //    btnSalvarProduto.Visibility = Visibility.Visible;
        //    btnSalvarProdutoEdit.Visibility = Visibility.Collapsed;
        //    gridPesquisaProduto.Visibility = Visibility.Collapsed;

        //    dataGridProduto.Items.Refresh();
        //    dataGridProduto.Visibility = Visibility.Collapsed;

        //    if (IdProdutoLista < 1)
        //        IdProdutoLista = 1;

        //    idProdutoBox.Text = $"{IdProdutoLista}";
        //}

        //private void BtnSalvarProduto_Click(object sender, RoutedEventArgs e)
        //{
        //    SalvarProduto();
        //}

        //public void BtnCancelarProduto_Click(object sender, RoutedEventArgs e)
        //{
        //    nomeProdutoBox.Text = "";
        //    codigoProdutoBox.Text = "";
        //    valorProdutoBox.Text = "";

        //    dataGridProduto.Visibility = Visibility.Visible;
        //    gridCadastrarProduto.Visibility = Visibility.Collapsed;
        //    gridPesquisaProduto.Visibility = Visibility.Visible;
        //}

        ////Para permitir apenas números
        //private void MinimoTB_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    AceitarApenasNumeros(minimoTB);
        //}

        //private void MaximoTB_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    AceitarApenasNumeros(maximoTB);
        //}

        //private void BtnPesquisarProduto_Click(object sender, RoutedEventArgs e)
        //{
        //    if (minimoTB.Text == "" || maximoTB.Text == "")
        //    {
        //        minimoTB.Text = "0";
        //        maximoTB.Text = "9999999";
        //    }

        //    var dadosGrid = produtos.Where(p => p.NomeProduto.Contains(txtBoxPesquisaProduto.Text) || p.Codigo.Contains(txtBoxPesquisaProduto.Text)).ToList();

        //    if (dadosGrid.Count > 0)
        //    {
        //        dataGridProduto.ItemsSource = dadosGrid;
        //    }
        //    else
        //    {
        //        MessageBox.Show("Produto não encontrado!");
        //    }

        //    var dadosValor = produtos.Where(p => p.Valor >= double.Parse(minimoTB.Text) && p.Valor <= double.Parse(maximoTB.Text)).ToList();

        //    if (dadosValor.Count > 0)
        //    {
        //        dataGridProduto.ItemsSource = dadosValor;
        //    }
        //}

        //private void EditarProduto_Click(object sender, RoutedEventArgs e)
        //{
        //   // dataGridPessoa.Visibility = Visibility.Collapsed;
        //    gridCadastrarProduto.Visibility = Visibility.Collapsed;
        //    gridCadastrarProduto.Visibility = Visibility.Visible;
        //    dataGridProduto.Visibility = Visibility.Collapsed;
        //    gridPesquisaProduto.Visibility = Visibility.Collapsed;
        //    btnSalvarProduto.Visibility = Visibility.Collapsed;
        //    btnSalvarProdutoEdit.Visibility = Visibility.Visible;

        //    var data = dataGridProduto.SelectedIndex;


        //    if (data != -1)
        //    {
        //        idProdutoBox.Text = produtos[data].IdProduto.ToString();
        //        nomeProdutoBox.Text = produtos[data].NomeProduto;
        //        codigoProdutoBox.Text = produtos[data].Codigo;
        //        valorProdutoBox.Text = produtos[data].Valor.ToString();
        //    }
        //}

        //private void BtnSalvarProdutoEdit_Click(object sender, RoutedEventArgs e)
        //{
        //    SalvarProdutoEdit();
        //}

        //private void BtnEditarProduto_Click(object sender, RoutedEventArgs e)
        //{
        //    if (dataGridProduto.HasItems)
        //    {
        //       // dataGridPessoa.Visibility = Visibility.Collapsed;
        //        gridCadastrarProduto.Visibility = Visibility.Collapsed;
        //        gridCadastrarProduto.Visibility = Visibility.Visible;
        //        dataGridProduto.Visibility = Visibility.Collapsed;
        //        gridPesquisaProduto.Visibility = Visibility.Collapsed;
        //    }
        //    else
        //    {
        //        MessageBox.Show("Nenhum cadastro para alterar");
        //    }
        //}

        //private void ExcluirProduto_Click(object sender, RoutedEventArgs e)
        //{
        //    dynamic data = dataGridProduto.SelectedItem;
        //    produtos.Remove(data);
        //    ExportarXmlProduto("C:\\Produtos.xml");
        //}

        //#endregion

        //#region Exportação de XML

        

       

        //private void ExportarXmlProduto(string fileName)
        //{
        //    var xml = new XElement("Produto",
        //        new XElement("IdProdutoLista", IdProdutoLista),
        //        from p in produtos
        //        select new XElement("Produto",
        //            new XElement("IdProduto", p.IdProduto),
        //            new XElement("NomeProduto", p.NomeProduto),
        //            new XElement("Codigo", p.Codigo),
        //            new XElement("Valor", p.Valor)
        //        )
        //    );
        //    xml.Save(fileName);
        //}

        //private void LerXmlProduto(string fileName)
        //{
        //    try
        //    {
        //        var xml = XElement.Load(fileName);

        //        IdProdutoLista = int.Parse(xml.Element("IdProdutoLista").Value);

        //        foreach (var element in xml.Elements("Produto"))
        //        {
        //            var produtoLerXml = new Produto
        //            {
        //                IdProduto = int.Parse(element.Element("IdProduto").Value),
        //                NomeProduto = element.Element("NomeProduto").Value,
        //                Codigo = element.Element("Codigo").Value,
        //                Valor = double.Parse(element.Element("Valor").Value),
        //            };

        //            produtos.Add(produtoLerXml);
        //        }
        //    }
        //    catch
        //    {
        //        return;
        //    }
        //}

        //private void ExportarXmlPedido()
        //{
        //    var arquivoXml = @"C:\\Pedidos.xml";
        //    using (var stream = new StreamWriter(arquivoXml))
        //    {
        //        XmlSerializer serializador = new XmlSerializer(typeof(ObservableCollection<Pedido>));
        //        serializador.Serialize(stream, pedidos);
        //    }
        //}

        //private static ObservableCollection<Pedido> LerXmlPedido()
        //{
        //    ObservableCollection<Pedido> lista = new ObservableCollection<Pedido>();
        //    try
        //    {
        //        var arquivoXml = @"C:\\Pedidos.xml";
        //        using (StreamReader stream = new StreamReader(arquivoXml))
        //        {
        //            XmlSerializer serializador = new XmlSerializer(typeof(ObservableCollection<Pedido>));
        //            lista = (ObservableCollection<Pedido>)serializador.Deserialize(stream);
        //        }
               
        //        return lista;
                
        //    }
        //    catch
        //    {
        //        return lista;
        //    }
        //}

        //#endregion

        //#region Botões Pedido
        //private void BtnDetalhesPedido_Click(object sender, RoutedEventArgs e)
        //{
        //  //  dynamic data = dataGridPessoa.SelectedItem;
        //   // string indexData = data.NomePessoa;
        //  //  var indexList = pedidos.Where(p => p.NomePessoa == indexData).ToList();

        //   // if (indexList.Count > 0)
        //   // {

        //   //    // dataGridPessoa.Visibility = Visibility.Collapsed;
        //   //     //gridPesquisaPessoa.Visibility = Visibility.Collapsed;

        //   //     dataGridPedidos.Visibility = Visibility.Visible;
        //   //     gridPesquisaStatus.Visibility = Visibility.Visible;

        //   //     dataGridPedidos.ItemsSource = indexList;

        //   //     btnPessoa.Content = "Voltar";
        //   //     btnPessoa.Background = Brushes.LightBlue;
        //   ////     txtNomePedido.Text = indexData;
        //   // }
        //   // else
        //   // {
        //   //     MessageBox.Show("Nenhum pedido encontrado!!");
        //   // }
        //}

        //private void BtnIncluirPedido_Click(object sender, RoutedEventArgs e)
        //{
        //   // dynamic data = dataGridPessoa.SelectedItem;
        //   // string indexData = data.NomePessoa;


        //    if (IdPedidoLista < 1)
        //        IdPedidoLista = 1;

        //    idPedidoBox.Text = $"{IdPedidoLista}";

        //    gridPedido.Visibility = Visibility.Visible;

        //    //btnCadastrarPessoa.Visibility = Visibility.Collapsed;
        //    //dataGridPessoa.Visibility = Visibility.Collapsed;
        //    //dataGridProduto.Visibility = Visibility.Collapsed;
        //    //gridPesquisaPessoa.Visibility = Visibility.Collapsed;

        //   // nomePedidoPessoaBox.Text = indexData;
        //    DataPedidoBox.Text = DateTime.Now.ToString("dd-MM-yyyy");

        //}

        //private void BtnSalvaPedido_Click(object sender, RoutedEventArgs e)
        //{
        //    double valorPedido = 0;


        //    if (FormaPagPedidoBox.SelectedValue != null && produtosListBox.HasItems)
        //    {

        //        foreach (var item in produtosPedido)
        //        {
        //            var valorPorQntd = item.Valor * item.QntdProduto;

        //            valorPedido += valorPorQntd;
        //        }

        //        pedidos.Add(new Pedido(IdPedidoLista, nomePedidoPessoaBox.Text.ToUpper(), produtosPedido, valorPedido, Convert.ToInt32(FormaPagPedidoBox.SelectedValue), 0, IdPedidoLista + 1));

        //        //dataGridPessoa.Visibility = Visibility.Visible;
        //        //btnCadastrarPessoa.Visibility = Visibility.Visible;
        //        //gridPesquisaPessoa.Visibility = Visibility.Visible;

        //        gridPedido.Visibility = Visibility.Collapsed;

        //        MessageBox.Show("Cadastro efetuado com sucesso");


        //        IdPedidoLista++;
        //        ExportarXmlPedido();
        //        qntdProdPedBox.Text = "";
        //        PedProdutosBox.Text = "";
        //        produtosListBox.Items.Clear();
        //        valorProdutoBox.Text = "";
        //        FormaPagPedidoBox.Text = "";
        //        produtosPedido.Clear();

        //    }
        //    else
        //    {
        //        MessageBox.Show("Preencha todos os campos obrigatórios!");

        //    }
        //}

        //private void BtnCancelarPedido_Click(object sender, RoutedEventArgs e)
        //{
        //    idPedidoBox.Text = "";
        //    nomePedidoPessoaBox.Text = "";
        //    qntdProdPedBox.Text = "";
        //    PedProdutosBox.Text = "";
        //    produtosListBox.Items.Clear();
        //    DataPedidoBox.Text = "";
        //    FormaPagPedidoBox.Text = "";

        //    //dataGridPessoa.Visibility = Visibility.Visible;
        //    //gridPesquisaPessoa.Visibility = Visibility.Visible;
        //    //btnCadastrarPessoa.Visibility = Visibility.Visible;

        //    gridPedido.Visibility = Visibility.Collapsed;

        //}

        //private void ExpandirPedido_Click(object sender, RoutedEventArgs e)
        //{
        //    dynamic data = dataGridPedidos.SelectedItem;
        //    string indexNome = data.NomePessoa;
        //    int indexPed = data.IdPedido;
        //    var indexList = pedidos.Where(p => p.NomePessoa == indexNome && p.IdPedido == indexPed).ToList();

        //    dataGridPedidoExpandido.Visibility = Visibility.Visible;

        //    foreach (var item in indexList)
        //    {
        //        dataGridPedidoExpandido.ItemsSource = item.Produtos.ToList();
        //    }

        //}

        //private void IncluirProdutoPedido_Click(object sender, RoutedEventArgs e)
        //{
        //    var dadoProduto = produtos.IndexOf(produtos.Where(p => p.NomeProduto == PedProdutosBox.Text).FirstOrDefault());


        //    if (dadoProduto != -1 && PedProdutosBox.Text != "" && qntdProdPedBox.Text != "" && int.Parse(qntdProdPedBox.Text) >= 1)
        //    {
        //        produtosListBox.Items.Add($"{PedProdutosBox.Text}  Qntd: {qntdProdPedBox.Text}   R$ {produtos[dadoProduto].Valor}");

        //        produtosPedido.Add(new Produto(produtos[dadoProduto].IdProduto, PedProdutosBox.Text, produtos[dadoProduto].Valor, int.Parse(qntdProdPedBox.Text)));
        //    }
        //    else
        //    {
        //        MessageBox.Show("Campos necessarios não preenchidos corretamente");
        //    }

        //    PedProdutosBox.Text = "";
        //    qntdProdPedBox.Text = "";
        //}

        //private void ValorProdutoBox_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    if (sender is TextBox textBox)
        //    {
        //        if (double.TryParse(textBox.Text, out double valor))
        //        {
        //            textBox.Text = valor.ToString("N2");
        //        }
        //        else
        //        {
        //            MessageBox.Show("Digite um valor numérico válido.");
        //        }
        //    }
        //}


        //private void BtnPedidoPendente_Click(object sender, RoutedEventArgs e)
        //{
        //    PesquisaStatus(0);
        //}

        //private void BtnPedidoPago_Click(object sender, RoutedEventArgs e)
        //{
        //    PesquisaStatus(1);
        //}

        //private void BtnPedidoEntregue_Click(object sender, RoutedEventArgs e)
        //{
        //    PesquisaStatus(3);
        //}

        //private void BtnPedidoTodos_Click(object sender, RoutedEventArgs e)
        //{
        //    VoltaDadosPedido();
        //}

        //public void PesquisaStatus(int status)
        //{
        //    var dado = pedidos.Where(p => p.Status == (Status)status && p.NomePessoa == txtNomePedido.Text).ToList();

        //    if (dado.Count > 0)
        //        dataGridPedidos.ItemsSource = dado;
        //    else
        //    {
        //        MessageBox.Show("Pedidos não encontrados!");

        //        VoltaDadosPedido();
        //    }

        //}
        //public void VoltaDadosPedido()
        //{
        //    var indexList = pedidos.Where(p => p.NomePessoa == txtNomePedido.Text).ToList();

        //    dataGridPedidos.ItemsSource = indexList;
        //}

        //private void BtnMarcarPago_Click(object sender, RoutedEventArgs e)
        //{
        //    AlterarStatus(1);
        //}

        //private void BtnMarcarEnviado_Click(object sender, RoutedEventArgs e)
        //{
        //    AlterarStatus(2);
        //}

        //private void BtnMarcarRecebido_Click(object sender, RoutedEventArgs e)
        //{
        //    AlterarStatus(3);
        //}

        //private void AlterarStatus(int status)
        //{
        //    dynamic data = dataGridPedidos.SelectedItem;
        //    int indexPed = data.IdPedido;
        //    var indexList = pedidos.Where(p => p.IdPedido == indexPed).FirstOrDefault();

        //    indexList.Status = (Status)status;
        //    dataGridPedidos.Items.Refresh();
        //    ExportarXmlPedido();
        //}
        #endregion
    }
}