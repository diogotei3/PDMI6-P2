using PDMI6Prova2.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDMI6Prova2.Services
{
    public class DatabaseService : IDatabaseService
    {

        private SQLiteAsyncConnection _dbConnection;

        public async Task InitializeAsync()
        {
            await InitializeConnection();
        }
        public async Task InitializeConnection()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(FileSystem.Current.AppDataDirectory, "livros.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<Livro>();
            }
        }

        public async void AddLivro(Livro livro)
        {
            await _dbConnection.InsertAsync(livro);
        }
        public async void DeleteLivro(Livro livro)
        {
            await _dbConnection.DeleteAsync(livro);
        }

        public async Task<int> DeleteAll()
        {
            return await _dbConnection.DeleteAllAsync<Livro>();
        }

        public async void UpdateLivro(Livro livro)
        {
            await _dbConnection.UpdateAsync(livro);
        }

        public async Task<List<Livro>> GetLivros()
        {
            return await _dbConnection.Table<Livro>().ToListAsync();
        }

        public async Task<Livro> GetLivroById(int idLivro)
        {
            var livros = await _dbConnection.QueryAsync<Livro>($"Select * From { nameof(Livro)} where IdLivro = {idLivro} ");
            return livros.FirstOrDefault();
        }
    }
}