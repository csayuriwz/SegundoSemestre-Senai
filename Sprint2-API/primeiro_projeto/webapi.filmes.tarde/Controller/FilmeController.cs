
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    [Produces("Aplications/json")]
    public class FilmeController : ControllerBase
    {
    }
}
