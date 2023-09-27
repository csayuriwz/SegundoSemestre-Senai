using health_clinic.webapi.Context;
using health_clinic.webapi.Domain;
using health_clinic.webapi.Interfaces;

namespace health_clinic.webapi.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly ClinicContext _clinicContext;

        public ConsultaRepository()
        {
            _clinicContext = new ClinicContext();
        }
        public void Atualizar(Guid id, Consulta consulta)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Consulta consulta)
        {
            _clinicContext.Consulta.Add(consulta);

            _clinicContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Consulta> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
