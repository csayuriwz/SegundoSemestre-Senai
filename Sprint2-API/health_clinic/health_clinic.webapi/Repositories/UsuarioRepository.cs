using health_clinic.webapi.Context;
using health_clinic.webapi.Domain;
using health_clinic.webapi.Interfaces;

namespace health_clinic.webapi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ClinicContext _clinicContext;

        public UsuarioRepository()
        {
            _clinicContext = new ClinicContext();
        }
        public void Atualizar(Guid id, Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPorId(Guid id)
        {
            return _clinicContext.Usuario.FirstOrDefault(e => e.IdUsuario == id)!;
        }

        public void Cadastrar(Usuario usuario)
        {
            _clinicContext.Usuario.Add(usuario);

            _clinicContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            try
            {
                Usuario usuarioB = _clinicContext.Usuario.Find(id);

                if (usuarioB != null)
                {
                    _clinicContext.Usuario.Remove(usuarioB);
                }

                _clinicContext.SaveChanges();
            }

            catch (Exception)
            {

                throw;
            }
        }

        public List<Usuario> ListarTodos()
        {
            return _clinicContext.Usuario.ToList();
        }
    }
}
