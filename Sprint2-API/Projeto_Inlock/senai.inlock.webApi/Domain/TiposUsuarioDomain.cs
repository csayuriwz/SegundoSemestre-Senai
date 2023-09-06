using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi_.Domain
{
    public class TiposUsuarioDomain
    {
        public int IdTiposUsuario { get; set; }

        [Required(ErrorMessage = " O titulo eh obrigatorio !")]
        public string Titulo { get; set; }
    }
}
