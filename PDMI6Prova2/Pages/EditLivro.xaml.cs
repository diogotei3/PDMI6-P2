using PDMI6Prova2.Models;
using PDMI6Prova2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PDMI6Prova2.Pages
{
    public partial class EditLivro : ContentPage
    {
        private Livro currentLivro;
        public DatabaseService service = new DatabaseService();

        public EditLivro(Livro livro)
        {
            InitializeComponent();
            iniciarBanco();

            currentLivro = livro;
            BindingContext = livro;
        }

        public async void iniciarBanco()
        {
            await service.InitializeAsync();
        }

        private async void onEditLivro(object sender, EventArgs e)
        {
            Livro livro = currentLivro;
            if (livro != null)
            {
                service.UpdateLivro(currentLivro);
                await Navigation.PushAsync(new MainPage());
            }
        }

        private async void onCancel(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();

        }
    }
}