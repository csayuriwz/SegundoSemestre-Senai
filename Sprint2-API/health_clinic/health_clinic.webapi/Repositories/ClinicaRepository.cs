using health_clinic.webapi.Context;
using health_clinic.webapi.Domain;
using health_clinic.webapi.Interfaces;

namespace health_clinic.webapi.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        private readonly ClinicContext _clinicContext;

        public ClinicaRepository()
        {
            _clinicContext = new ClinicContext();
        }
        public void Atualizar(Guid id, Clinica clinica)
        {
            Clinica clinicaB = _clinicContext.Clinica.Find(id);

            if ( clinicaB != null)
            {
                clinicaB.Endereco = clinica.Endereco;
                clinicaB.CNPJ = clinica.CNPJ;
                clinicaB.RazaoSocial = clinica.RazaoSocial;
                clinicaB.NomeFantasia = clinica.NomeFantasia;
                clinicaB.HorarioAbertura = clinica.HorarioAbertura;
                clinicaB.HorarioFechamento = clinica.HorarioFechamento;

                _clinicContext.Clinica.Update(clinicaB);

                _clinicContext.SaveChanges();

            }
        }

        public void Cadastrar(Clinica clinica)
        {
            _clinicContext.Clinica.Add(clinica);

            _clinicContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            try
            {
                Clinica clinicaB = _clinicContext.Clinica.Find(id);

                if (clinicaB != null)
                {
                    _clinicContext.Clinica.Remove(clinicaB);
                }

                _clinicContext.SaveChanges();
            }

            catch (Exception)
            {

                throw;
            }
        }

        public List<Clinica> ListarTodos()
        {
            return _clinicContext.Clinica.ToList();
        }


    }
}
