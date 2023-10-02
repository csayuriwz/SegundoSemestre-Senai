using health_clinic.webapi.Context;
using health_clinic.webapi.Domain;
using health_clinic.webapi.Interfaces;
using health_clinic.webapi.Utils;
using webapi.event_.tarde.Domains;

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
            Usuario usuarioB = _clinicContext.Usuario.Find(id);

            if (usuarioB != null)
            {
                usuarioB.Senha = usuario.Senha;
                usuarioB.Email = usuario.Email;
                

                _clinicContext.Usuario.Update(usuarioB);

                _clinicContext.SaveChanges();

            }
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
