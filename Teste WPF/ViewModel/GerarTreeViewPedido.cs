using System;
using System.Windows.Controls;
using Teste_WPF.ViewModels;

namespace Teste_WPF
{
    public class GerarTreeViewPedido
    {
        public StackPanel GerarTreePedidoLevel2(Pedido pedido)
        { 
            StackPanel level2_TVI = new StackPanel();

            TreeViewItem pessoaTVI = new TreeViewItem();
            pessoaTVI.Header = "Nome: " + pedido.Pessoas.NomePessoa;

            TreeViewItem produtosPedidoTVI = new TreeViewItem();
            produtosPedidoTVI.Header = "Produtos:";

            TreeViewItem valorTotalTVI = new TreeViewItem();
            valorTotalTVI.Header = "Valor: R$ " + pedido.ValorTotal;

            TreeViewItem dataVendalTVI = new TreeViewItem();
            dataVendalTVI.Header = "Data do pedido: " + pedido.DataVenda;

            TreeViewItem formaPagamentoTVI = new TreeViewItem();
            formaPagamentoTVI.Header = "Forma de pagamento: " + pedido.FormaPagamento;

            TreeViewItem statusTVI = new TreeViewItem();
            statusTVI.Header = "Status: " + pedido.Status;

            produtosPedidoTVI.Items.Add(GerarTreePedidoLevel3(pedido));

            level2_TVI.Children.Add(pessoaTVI);
            level2_TVI.Children.Add(produtosPedidoTVI);
            level2_TVI.Children.Add(valorTotalTVI);
            level2_TVI.Children.Add(dataVendalTVI);
            level2_TVI.Children.Add(formaPagamentoTVI);
            level2_TVI.Children.Add(statusTVI);

            return level2_TVI;
          
        }

        public Grid GerarTreePedidoLevel3(Pedido pedido)
        {
            Grid level3_TVI = new Grid();
            ColumnDefinition col1 = new ColumnDefinition();
            ColumnDefinition col2 = new ColumnDefinition();

            RowDefinition row1 = new RowDefinition();
            RowDefinition row2 = new RowDefinition();

            level3_TVI.ColumnDefinitions.Add(col1);
            level3_TVI.ColumnDefinitions.Add(col2);
            level3_TVI.RowDefinitions.Add(row1);
            level3_TVI.RowDefinitions.Add(row2);

            TreeViewItem produto1TVI = new TreeViewItem();
            produto1TVI.Header = pedido.Produtos.NomeProduto;

            TreeViewItem qntdProduto1TVI = new TreeViewItem();
            qntdProduto1TVI.Header = "Qtd: " + pedido.Produtos.QntProduto;

            TreeViewItem produto2TVI = new TreeViewItem();
            produto2TVI.Header = "Carro";

            TreeViewItem qntdProduto2TVI = new TreeViewItem();
            qntdProduto2TVI.Header = "Qtd: 45687984";

            Grid.SetRow(produto1TVI, 0);
            Grid.SetColumn(produto1TVI, 0);

            Grid.SetRow(qntdProduto1TVI, 0);
            Grid.SetColumn(qntdProduto1TVI, 1);

            Grid.SetRow(produto2TVI, 1);
            Grid.SetColumn(produto2TVI, 0);

            Grid.SetRow(qntdProduto2TVI, 1);
            Grid.SetColumn(qntdProduto2TVI, 1);

            level3_TVI.Children.Add(produto1TVI);
            level3_TVI.Children.Add(qntdProduto1TVI);

            level3_TVI.Children.Add(produto2TVI);
            level3_TVI.Children.Add(qntdProduto2TVI);

            return level3_TVI;
        }
    }
}
