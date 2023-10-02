using health_clinic.webapi.Domain;
using health_clinic.webapi.Interfaces;
using health_clinic.webapi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.tarde.Domains;

namespace health_clinic.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tusuarioRepository { get; set; }

        public TipoUsuarioController()
        {
            _tusuarioRepository = new TipoUsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(TipoUsuario tipousuario)
        {
            try
            {
                _tusuarioRepository.Cadastrar(tipousuario);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _tusuarioRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tusuarioRepository.ListarTodos());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(Guid id, TipoUsuario tipousuario)
        {
            try
            {
                _tusuarioRepository.Atualizar(id, tipousuario);

                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
