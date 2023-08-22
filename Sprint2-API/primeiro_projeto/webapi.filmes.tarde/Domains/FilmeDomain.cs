using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.tarde.Domains
{
    /// <summary>
    /// Classe que representa a entidade(tabela) filme
    /// </summary>
    public class FilmeDomain
    {
        public int IdFilme { get; set; }


        [Required (ErrorMessage = "O titulo do filme eh obrigatorio")]
        public string? Titulo { get; set; }


        public int IdGenero { get; set; }


        //referencia para a classe genero
        public GeneroDomain? Genero { get; set; }

    }
}
