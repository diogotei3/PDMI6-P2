using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDMI6Prova2.Models
{
    public class Livro
    {
        [PrimaryKey, AutoIncrement] public int IdLivro { get; set; }
        [Required] public string NomeLivro { get; set; }
        [Required] public string NomeAutor { get; set; }
        [Required] public string EmailAutor { get; set; }
        [Required]public string ISBN { get; set; }

        public Livro(string nome, string autor, string email, string iSBN)
        {
            NomeLivro = nome;
            NomeAutor = autor;
            EmailAutor = email;
            ISBN = iSBN;
        }

        public Livro()
        {

        }
    }
}
