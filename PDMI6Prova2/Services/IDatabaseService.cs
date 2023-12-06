using PDMI6Prova2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDMI6Prova2.Services
{
    public interface IDatabaseService
    {
        Task InitializeAsync();
        Task<List<Livro>> GetLivros();
        Task<Livro> GetLivroById(int livroId);
        void AddLivro(Livro livro);
        void UpdateLivro(Livro livro);
        void DeleteLivro(Livro livro);
        Task<int> DeleteAll();
    }
}
