using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class ListaProduto : ContentPage
{
    public ListaProduto()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        lista_produtos.ItemsSource = await App.Db.GetAll();
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
}