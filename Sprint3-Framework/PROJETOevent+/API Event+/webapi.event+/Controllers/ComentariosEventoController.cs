using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.ContentModerator;
using System.Text;
using webapi.event_.Domains;
using webapi.event_.Repositories;

namespace webapi.event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ComentariosEventoController : ControllerBase
    {
        //acesso aos metodos do repositorio
        ComentariosEventoRepository comentario = new ComentariosEventoRepository();

        //armazena dados da API externa (IA - Azure)
        private readonly ContentModeratorClient _contentModeratorClient;

        //CTOR QUE RECEBE OS DADOS NECESSARIOS PARA O SERVICO EXTERNO, como parametro temos o objeto do tipo ContentModeratorClient
        public ComentariosEventoController(ContentModeratorClient contentModeratorClient)
        {
            _contentModeratorClient = contentModeratorClient;
        }


        [HttpPost("CadastroIA")]
        public async Task<IActionResult> PostIA(ComentariosEvento comentarioEvento)
        {
            try
            {
                //se a descricao do comentario nao for passado no objeto
                if (string.IsNullOrEmpty(comentarioEvento.Descricao))
                {
                    return BadRequest("O texto a ser analisado nao pode ser vazio!");
                }

                //converte a string (descricao do comentario em um MemoryStream)
                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(comentarioEvento.Descricao));

                //realiza a moderacao do conteudo(descricao do comentario)
                var moderationResult = await _contentModeratorClient.TextModeration
                    .ScreenTextAsync("text/plain", stream, "por", false, false, null, true);

                if (moderationResult.Terms != null)
                {
                    comentarioEvento.Exibe = false;

                    comentario.Cadastrar(comentarioEvento);
                }
                else
                {
                    comentarioEvento.Exibe = true;

                    comentario.Cadastrar(comentarioEvento);
                }

                return StatusCode(201, comentarioEvento);
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
                return Ok(comentario.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("ListarSomenteExibe")]
        public IActionResult GetIA()
        {
            try
            {
                return Ok(comentario.ListarSomenteExibe());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpGet("BuscarPorIdUsuario")]
        public IActionResult GetByUser(Guid idUsuario, Guid idEvento)
        {
            try
            {
                return Ok(comentario.BuscarPorIdUsuario(idUsuario,idEvento));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        public IActionResult Post (ComentariosEvento novoComentario)
        {
            try
            {
                comentario.Cadastrar(novoComentario);
                return StatusCode(201, novoComentario);
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
                comentario.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


    }
}
