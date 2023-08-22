using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.tarde.Domains
{
    /// <summary>
    /// classe que representa a entidade(tabela) genero
    /// </summary>
    public class GeneroDomain
    {
        public int IdGenero { get; set; }


        [Required (ErrorMessage ="O nome do genero eh obrigatorio !")]
        public string? Nome { get; set; }

        
    }
}
