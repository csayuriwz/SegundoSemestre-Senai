using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi_.Domain;
using senai.inlock.webApi_.Interface;
using senai.inlock.webApi_.Repository;
using System.Data;

namespace senai.inlock.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EstudioController : ControllerBase
    {
        private IEstudiosRepository _estudioRepository { get; set; }

        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<EstudiosDomain> listaEstudios = _estudioRepository.ListaEstudios();

                return Ok(listaEstudios);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(EstudiosDomain novoEstudio)
        {
            try
            {
                _estudioRepository.Cadastrar(novoEstudio);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _estudioRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

    }
}