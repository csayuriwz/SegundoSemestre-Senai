using webapi.event_.tarde.Domains;

namespace health_clinic.webapi.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        void Cadastrar(TipoUsuario tipousuario);

        void Deletar(Guid id);

        TipoUsuario BuscarPorId(Guid id);

        void Atualizar(Guid id, TipoUsuario tipoUsuario);

        List<TipoUsuario> ListarTodos();
    }
}
