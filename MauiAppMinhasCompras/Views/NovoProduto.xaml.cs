using MauiAppMinhasCompras.Models;
using MauiAppMinhasCompras.Helpers;

namespace MauiAppMinhasCompras.Views;

public partial class NovoProduto : ContentPage
{
    public NovoProduto()
    {
        InitializeComponent();
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txt_descricao.Text))
        {
            await DisplayAlertAsync("Atenção", "Digite a descrição do produto.", "OK");
            return;
        }

        if (!double.TryParse(txt_quantidade.Text, out double quantidade))
        {
            await DisplayAlertAsync("Atenção", "Digite uma quantidade válida.", "OK");
            return;
        }

        if (!double.TryParse(txt_preco.Text, out double preco))
        {
            await DisplayAlertAsync("Atenção", "Digite um preço válido.", "OK");
            return;
        }

        Produto produto = new Produto
        {
            Descricao = txt_descricao.Text,
            Quantidade = quantidade,
            Preco = preco
        };

        await App.Db.Insert(produto);

        await DisplayAlertAsync("Sucesso", "Produto cadastrado!", "OK");

        txt_descricao.Text = "";
        txt_quantidade.Text = "";
        txt_preco.Text = "";
 
}
}