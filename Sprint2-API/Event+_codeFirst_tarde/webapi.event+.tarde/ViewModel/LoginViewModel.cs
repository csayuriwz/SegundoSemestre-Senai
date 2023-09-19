using System.ComponentModel.DataAnnotations;

namespace webapi.event_.tarde.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email obrigatorio!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha obrigatoria!")]
        public string Senha { get; set; }
    }
}
