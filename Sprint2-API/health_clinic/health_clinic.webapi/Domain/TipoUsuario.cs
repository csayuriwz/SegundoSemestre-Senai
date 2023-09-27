using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


    namespace webapi.event_.tarde.Domains
    {
        [Table(nameof(TipoUsuario))]
        public class TipoUsuario
        {
            [Key]
            public Guid IdTipoUsuario { get; set; } = Guid.NewGuid();

            [Column(TypeName = "VARCHAR(100)")]
            [Required(ErrorMessage = "Titulo do tipo do usuário é obrigatório!")]
            public string? Titulo { get; set; }

        }
    }

