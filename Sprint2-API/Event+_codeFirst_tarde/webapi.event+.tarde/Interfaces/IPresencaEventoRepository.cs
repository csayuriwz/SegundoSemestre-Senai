using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface IPresencaEventoRepository
    {
        void Cadastrar(PresencaEvento presencaevento);

        void Deletar(Guid id);

        PresencaEvento BuscarPorId(Guid id);

        void Atualizar(Guid id, PresencaEvento presencaevento);

        List<PresencaEvento> ListarTodos();

    }
}
