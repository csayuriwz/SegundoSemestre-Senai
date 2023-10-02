using health_clinic.webapi.Domain;

namespace health_clinic.webapi.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuario);

        void Deletar(Guid id);

        List<Usuario> ListarTodos();

        void Atualizar(Guid id, Usuario usuario);

   
    }
}
