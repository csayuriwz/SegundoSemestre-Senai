using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using webapi.event_.tarde.Domains;

namespace health_clinic.webapi.Domain
{
    [Table(nameof(Usuario))]
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();



        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O email é obrigatório!")]
        public string? Email { get; set; }



        [Column(TypeName = "CHAR(60)")]
        [Required(ErrorMessage = "A senha é obrigatória!")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "A senha deve contar de 6 a 60 caracteres")]
        public string? Senha { get; set; }


        //referencias para tabela de tipousuario (FK)
        [Required(ErrorMessage = "O tipo do usuario é obrigatório!")]
        public Guid IdTipoUsuario { get; set; }

        [ForeignKey(nameof(IdTipoUsuario))]
        public TipoUsuario? TipoUsuario { get; set; }
    }
}
