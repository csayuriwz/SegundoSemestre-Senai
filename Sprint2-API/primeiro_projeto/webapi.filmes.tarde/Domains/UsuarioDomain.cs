using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.tarde.Domains
{
    /// <summary>
    /// Classe que representa a entidade Usuario
    /// </summary>
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "O email eh obrigatorio!")]
        public string Email { get; set; }

        [StringLength(20,MinimumLength = 4, ErrorMessage = "O campo senha precisa de no minimo 4 e no maximo 20 caracteres!")]
        [Required(ErrorMessage ="A senha eh obrigatoria!")]
        public string Senha { get; set; }

        public string Permissao { get; set; }
    }
}
