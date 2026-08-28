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

        var lista = await App.Db.GetAll();

        produtos.Clear();

        foreach (var produto in lista)
        {
            produtos.Add(produto);
        }

        lista_produtos.ItemsSource = produtos;
    }

    private async void btn_novo_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NovoProduto());
    }

    private async void lista_produtos_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Produto produtoSelecionado)
        {
            await Navigation.PushAsync(new EditarProduto(produtoSelecionado));

            lista_produtos.SelectedItem = null;
        }
    }
    private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        string textoBusca = e.NewTextValue.ToLower();

        var produtosFiltrados = produtos
            .Where(p => p.Descricao.ToLower().Contains(textoBusca))
            .ToList();

        lista_produtos.ItemsSource = produtosFiltrados;
    }
}