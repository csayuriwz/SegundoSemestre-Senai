using webapi.filmes.tarde.Domains;

namespace webapi.filmes.tarde.Interfaces
{
    public interface IUsuarioRepository
    {
        /// <summary>
        /// metodo que busca um usuario por email e por senha
        /// </summary>
        /// <param name="email">email do usuario</param>
        /// <param name="senha">senha do usuario</param>
        /// <returns>objeto(usuario) buscado</returns>
       
        UsuarioDomain Login(string email, string senha);
    }
}
