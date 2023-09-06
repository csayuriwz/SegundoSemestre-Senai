using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi_.Domain
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        public int IdTiposUsuario { get; set; }

        [Required(ErrorMessage = "O email eh obrigatorio !")]
        public string Email { get; set; }

        [Required(ErrorMessage ="A senha eh obrigatoria")]
        public string Senha { get; set; }
    }
}
