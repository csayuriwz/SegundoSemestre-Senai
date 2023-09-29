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
            Consulta consultaB = _clinicContext.Consulta.Find(id);

            if (consultaB != null)
            {
                consultaB.Prontuario = consulta.Prontuario;
                consultaB.DataConsulta = consulta.DataConsulta;

              
            }
            _clinicContext.Consulta.Update(consultaB);
            _clinicContext.SaveChanges();
        }

        public void Cadastrar(Consulta consulta)
        {
            _clinicContext.Consulta.Add(consulta);

            _clinicContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            try
            {
                Consulta consultaB = _clinicContext.Consulta.Find(id);

                if (consultaB != null)
                {
                    _clinicContext.Consulta.Remove(consultaB);
                }

                _clinicContext.SaveChanges();
            }

            catch (Exception)
            {

                throw;
            }
        }

        public List<Consulta> ListarTodos()
        {
            return _clinicContext.Consulta.ToList();
        }
    }
}
