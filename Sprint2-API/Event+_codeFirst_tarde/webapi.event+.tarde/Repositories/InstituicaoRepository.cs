
using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
namespace webapi.event_.tarde.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private readonly EventContext _eventContext;

        public InstituicaoRepository()
        {
            _eventContext = new EventContext();
        }
        public void Atualizar(Guid id, Instituicao instituicao)
        {
            throw new NotImplementedException();
        }

        public Instituicao BuscarPorId(Guid id)
        {
            return _eventContext.Instituicao.FirstOrDefault(e => e.IdInstituicao == id)!;
        }

        public void Cadastrar(Instituicao instituicao)
        {
            _eventContext.Instituicao.Add(instituicao);

            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            try
            {
                TipoEvento instituicaoB = _eventContext.TipoEvento.Find(id);

                if (instituicaoB != null)
                {
                    _eventContext.TipoEvento.Remove(instituicaoB);
                }

                _eventContext.SaveChanges();
            }

            catch (Exception)
            {

                throw;
            }
        }

        public List<Instituicao> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
