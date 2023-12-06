using Microsoft.Maui.Controls;
using PDMI6Prova2.Models;
using PDMI6Prova2.Pages;
using PDMI6Prova2.Services;
using System.Collections.ObjectModel;

namespace PDMI6Prova2
{
    public partial class MainPage : ContentPage
    {
        public DatabaseService service = new DatabaseService();
        public List<Livro> Livros { get; set; }
        Livro livroTeste = new Livro
        {
            NomeLivro = "Livro Teste",
            NomeAutor = "Autor Teste",
            EmailAutor = "autor@teste.com",
            ISBN = "1234567890"
        };
        public Location location;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnAddLivroClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddLivro());
        }

        private async void OnEditLivroClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (button.BindingContext is Livro livro)
                {
                    await Navigation.PushAsync(new EditLivro(livro));
                }
            }
        }

        private async void OnDeleteLivroClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (button.BindingContext is Livro livro)
                {
                    bool remove = await DisplayAlert("Excluir item","Deseja deletar o livro?","Sim","Não");

                    if (remove)
                    {
                        service.DeleteLivro(livro);
                    }
                }
            }
        }

        protected override async void OnAppearing()
        {
            await service.InitializeAsync();
            //await service.DeleteAll();
            //await service.AddLivro(livroTeste);
            var livros = await service.GetLivros();
            listLivros.ItemsSource = new ObservableCollection<Livro>(livros);
            base.OnAppearing();
        }

        private async void OnFooterCreditsTappedAsync(object sender, EventArgs e)
        {
            await DisplayAlert("Créditos", "Realizado por Diogo Santos Teixeira e Guilherme Ferreira Santos", "OK!");
        }

    }

}
