
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;
using webapi.filmes.tarde.Repositories;
using webapi.filmes.tarde.Repositories.webapi.filmes.tarde.Repositories;

namespace webapi.filmes.tarde.Controller
{

    /// <summary>
    /// essa route define que a rota de uma requisicao sera no seguinte formato
    /// dominio/API/controller
    /// exemplo: http://localhost:5000/api/Filme
    /// </summary>
    [Route("api/[controller]")]

    /// <summary>
    /// define que eh um controlador de api
    /// </summary>
    [ApiController]

    ///<sumary>
    ///defini que o tipo e resposta da api eh json
    ///<sumary>
    [Produces("Application/json")]
    public class FilmeController : ControllerBase
    {

        /// <summary>
        /// Objeto que ira receber os metodos definidos na interface
        /// </summary>
        private IFilmeRepository _filmeRepository { get; set; }


        /// <summary>
        /// instancia do objeto _filmerepository para que haja referencia aos metodos no repositorio
        /// </summary>
        public FilmeController()
        {
            _filmeRepository = new FilmeRepository();
        }


        /// <summary>
        /// Endpoint que acessa o metodo de listar os filmes
        /// </summary>
        /// <returns>Lista de generos e um statuscode</returns>
        [HttpGet]
        public IActionResult Get()
        {

            try
            {
                //Cria uma lista para receber filmes
                List<FilmeDomain> ListaFilmes = _filmeRepository.ListarTodos();

                //retorna o status code 200 ok e a lista no formato JSON
                return Ok(ListaFilmes);
                //retorna OK lista filmes
            }
            catch (Exception erro)
            {
                //retorna um status code 400 - bad request, mensagem de erro
                return BadRequest(erro.Message);
            }
        }


        /// <summary>
        /// Endpoint que acessa o metodo de cadastrar filmes
        /// </summary>
        /// <param name="novoFilme">Objeto recebido a requisicao</param>
        /// <returns>StatusCode(201)</returns>
        [HttpPost]
        public IActionResult Post(FilmeDomain novoFilme)
        {

            try
            {
                _filmeRepository.Cadastrar(novoFilme);

                return Created("Objeto criado", novoFilme);
                //return StatusCode(201, novoGenero);

            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }


        /// <summary>
        /// EndPoint que acessa o metodo para deletar filmes cadastrados
        /// </summary>
        /// <param name="id">Id do objeto cadastrado</param>
        /// <returns>status code</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _filmeRepository.Deletar(id);

                return Ok(id);
                //return StatusCode(201, int id);

            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
        /// <summary>
        /// EndPoint para acessar um metodo que busca filmes por seu ID
        /// </summary>
        /// <param name="id">id do objeto a ser buscado</param>
        /// <returns>genero buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(id);

                if (filmeBuscado == null)
                {
                    return NotFound("o filme buscado nao foi encontrado !");
                }
                return Ok(filmeBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }


        /// <summary>
        /// EndPoint para acessar um metodo que atualiza os filmes por seus respectivos id's
        /// </summary>
        /// <param name="filme"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult PutIdBody(FilmeDomain filme)
        {
            try
            {
                FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(filme.IdFilme);

                if (filmeBuscado != null)
                {

                    try
                    {
                        _filmeRepository.AtualizarIdCorpo(filme);
                        return NoContent();
                    }
                    catch (Exception erro)
                    {
                        return BadRequest(erro.Message);
                    }

                }
                return NotFound("filme nao encontrado !");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);

            }

        }


        /// <summary>
        /// EndPoint que atualiza os filmes por sua URL
        /// </summary>
        /// <param name="id"></param>
        /// <param name="genero"></param>
        /// <returns></returns>
        [HttpPut("{id}")]

        public IActionResult PutIdUrl(int id, FilmeDomain filme)
        {
            try
            {
                FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(id);

                if (filmeBuscado != null)
                {

                    try
                    {
                        _filmeRepository.atualizarIdUrl(id, filme);
                        return NoContent();
                    }
                    catch (Exception erro)
                    {
                        return BadRequest(erro.Message);
                    }

                }
                return NotFound("Filme nao encontrado !");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);

            }
        }

    }
}

