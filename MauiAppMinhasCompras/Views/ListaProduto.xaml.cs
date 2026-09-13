using MauiAppMinhasCompras.Models;
using System.Collections.ObjectModel;

namespace MauiAppMinhasCompras.Views;

public partial class ListaProduto : ContentPage
{
    ObservableCollection<Produto> produtos = new ObservableCollection<Produto>();

    public ListaProduto()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        try
        {
            var lista = await App.Db.GetAll();

            produtos.Clear();

            foreach (var produto in lista)
            {
                produtos.Add(produto);
            }

            lista_produtos.ItemsSource = produtos;

            var categorias = produtos
                .Where(p => !string.IsNullOrWhiteSpace(p.Categoria))
                .Select(p => p.Categoria)
                .Distinct()
                .ToList();

            picker_categoria.ItemsSource = categorias;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private async void btn_novo_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NovoProduto());
    }

    private async void btn_excluir_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (sender is Button botao &&
                botao.CommandParameter is Produto produto)
            {
                bool resposta = await DisplayAlert(
                    "Confirmar exclusão",
                    $"Deseja realmente excluir o produto {produto.Descricao}?",
                    "Sim",
                    "Não");

                if (resposta)
                {
                    await App.Db.Delete(produto.Id);

                    produtos.Remove(produto);

                    await DisplayAlert(
                        "Sucesso!",
                        "Produto excluído com sucesso.",
                        "OK");
                }
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private async void lista_produtos_SelectionChanged(
        object sender,
        SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Produto produtoSelecionado)
        {
            await Navigation.PushAsync(
                new EditarProduto(produtoSelecionado));

            lista_produtos.SelectedItem = null;
        }
    }

    private void searchBar_TextChanged(
        object sender,
        TextChangedEventArgs e)
    {
        string textoBusca = e.NewTextValue.ToLower();

        var produtosFiltrados = produtos
            .Where(p => p.Descricao.ToLower().Contains(textoBusca))
            .ToList();

        lista_produtos.ItemsSource = produtosFiltrados;
    }

    private void picker_categoria_SelectedIndexChanged(
    object sender,
    EventArgs e)
    {
        if (picker_categoria.SelectedItem is string categoriaSelecionada)
        {
            var produtosFiltrados = produtos
                .Where(p => p.Categoria == categoriaSelecionada)
                .ToList();

            lista_produtos.ItemsSource = produtosFiltrados;

            double totalCategoria = produtosFiltrados
    .Sum(p => p.Quantidade * p.Preco);

            lbl_total_categoria.Text = $"Total da categoria: R$ {totalCategoria:F2}";
        }
    }
}