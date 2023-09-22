using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class TipoEventoRepository : ITipoEventoRepository
    {
        private readonly EventContext _eventContext;

        
        public TipoEventoRepository()
        {
            _eventContext = new EventContext();
        }
        public void Atualizar(Guid id, TipoEvento tipoEvento)
        {
            TipoEvento teventoB = _eventContext.TipoEvento.FirstOrDefault(e => e.IdTipoEvento == id);

            if (teventoB != null)
            {
                teventoB.Titulo = tipoEvento.Titulo;
            }

            _eventContext.TipoEvento.Update(teventoB);

            _eventContext.SaveChanges();
        }
    

        public TipoEvento BuscarPorId(Guid id)
        {
            return _eventContext.TipoEvento.FirstOrDefault(e => e.IdTipoEvento == id)!;
        }

        public void Cadastrar(TipoEvento tipoevento)
        {
            _eventContext.TipoEvento.Add(tipoevento);

            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            try
            {
                TipoEvento teventoBuscado = _eventContext.TipoEvento.Find(id);

                if (teventoBuscado != null)
                {
                    _eventContext.TipoEvento.Remove(teventoBuscado);
                }

                _eventContext.SaveChanges();
            }

            catch (Exception)
            {

                throw;
            }
        }

        public List<TipoEvento> ListarTodos()
        {
            return _eventContext.TipoEvento.ToList();
        }
    }
}