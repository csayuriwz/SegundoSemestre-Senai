using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class PresencaEventoRepository : IPresencaEventoRepository
    {
        private readonly EventContext _eventContext;

        public PresencaEventoRepository()
        {
            _eventContext = new EventContext();
        }
        public void Atualizar(Guid id, PresencaEvento presencaevento)
        {
            PresencaEvento presencaB = _eventContext.PresencaEvento.FirstOrDefault(e => e.IdPresencaEvento == id)!;

            if (presencaB != null)
            {
                presencaB.Situacao = presencaevento.Situacao;

                presencaB.Usuario = presencaevento.Usuario;

                presencaB.Evento = presencaevento.Evento;
            }

            _eventContext.PresencaEvento.Update(presencaB!);

            _eventContext.SaveChanges();
        }

        public PresencaEvento BuscarPorId(Guid id)
        {
            return _eventContext.PresencaEvento.FirstOrDefault(e => e.IdPresencaEvento == id)!;
        }

        public void Cadastrar(PresencaEvento presencaevento)
        {
            _eventContext.PresencaEvento.Add(presencaevento);

            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            try
            {
                TipoEvento presencaB = _eventContext.TipoEvento.Find(id);

                if (presencaB != null)
                {
                    _eventContext.TipoEvento.Remove(presencaB);
                }

                _eventContext.SaveChanges();
            }

            catch (Exception)
            {

                throw;
            }
        }

        public List<PresencaEvento> ListarMinhasPresencas(Guid id)
        {
            try
            {
                return _eventContext.PresencaEvento.Where(e => e.IdUsuario == id).ToList();
            }
            catch (Exception )
            {

                throw;
            }
        }

        public List<PresencaEvento> ListarTodos()
        {
            return _eventContext.PresencaEvento.ToList();
        }

    }
}
