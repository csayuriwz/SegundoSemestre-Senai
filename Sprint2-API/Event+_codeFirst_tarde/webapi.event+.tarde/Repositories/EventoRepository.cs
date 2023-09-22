using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
namespace webapi.event_.tarde.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly EventContext _eventContext;

        public EventoRepository()
        {
            _eventContext = new EventContext();
        }
        public void Atualizar(Guid id, Evento evento)
        {
            Evento eventoB = _eventContext.Evento.FirstOrDefault(e => e.IdEvento == id)!;

            if (eventoB != null)
            {
                eventoB.DataEvento = evento.DataEvento;

                eventoB.Descricao = evento.Descricao;

                eventoB.NomeEvento = evento.NomeEvento;

                eventoB.IdInstituicao= evento.IdInstituicao;

                eventoB.IdTipoEvento= evento.IdTipoEvento;
            }

            _eventContext.Evento.Update(eventoB!);

            _eventContext.SaveChanges();
        }

        public Evento BuscarPorId(Guid id)
        {
            return _eventContext.Evento.FirstOrDefault(e => e.IdTipoEvento == id)!;
        }

        public void Cadastrar(Evento evento)
        {
            _eventContext.Evento.Add(evento);

            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            try
            {
                Evento eventoB = _eventContext.Evento.Find(id);

                if (eventoB != null)
                {
                    _eventContext.Evento.Remove(eventoB);
                }

                _eventContext.SaveChanges();
            }

            catch (Exception)
            {

                throw;
            }
        }

        public List<Evento> ListarTodos()
        {
            return _eventContext.Evento.ToList();
        }
    }
}
