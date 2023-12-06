using PDMI6Prova2.Models;
using PDMI6Prova2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDMI6Prova2.Pages
{
    public partial class AddLivro : ContentPage
    {
        public DatabaseService service = new DatabaseService();

        public AddLivro()
        {
            InitializeComponent();
            iniciarBanco();
        }

        public async void iniciarBanco()
        {
            await service.InitializeAsync();
        }

        private async void onAddLivro(object sender, EventArgs e)
        {
            Livro livro = currentLivro();

            if (livro != null)
            {
                service.AddLivro(livro);
                await Navigation.PopModalAsync();
            }
        }

        private async void onCancel(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();

        }

        private Livro currentLivro()
        {
            if (string.IsNullOrWhiteSpace(NomeLivro.Text) || string.IsNullOrWhiteSpace(NomeAutor.Text) ||
                string.IsNullOrWhiteSpace(EmailAutor.Text) ||string.IsNullOrWhiteSpace(ISBN.Text))
            {
                DisplayAlert("", "Preencha todos os campos!", "Ok!");
                return null;
            }

            return new Livro(NomeLivro.Text, NomeAutor.Text, EmailAutor.Text, ISBN.Text);
        }
    }
}