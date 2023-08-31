using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;
using webapi.filmes.tarde.Repositories;

namespace webapi.filmes.tarde.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioController() 
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]

        public IActionResult Login(string email, string senha) 
        {
            try
            {
                UsuarioDomain usuarioBuscado = _usuarioRepository.Login(email, senha);

                if (usuarioBuscado == null)
                {
                    return NotFound("Usuario nao encontrado, email ou senha invalidos!");
                }

                return Ok(usuarioBuscado);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
