using health_clinic.webapi.Context;
using health_clinic.webapi.Domain;
using health_clinic.webapi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace health_clinic.webapi.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly ClinicContext _clinicContext;

        public FeedbackRepository()
        {
            _clinicContext = new ClinicContext();
        }
        public void Atualizar(Guid id, Feedback feedback)
        {
            Feedback feedbackB = _clinicContext.Feedback.Find(id);

            if (feedbackB != null)
            {
                feedbackB.Descricao = feedback.Descricao;
               
            }
            _clinicContext.Feedback.Update(feedbackB);
            _clinicContext.SaveChanges();
        }

        public void Cadastrar(Feedback feedback)
        {
            _clinicContext.Feedback.Add(feedback);

            _clinicContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            try
            {
                Feedback feedbackB = _clinicContext.Feedback.Find(id);

                if (feedbackB != null)
                {
                    _clinicContext.Feedback.Remove(feedbackB);
                }

                _clinicContext.SaveChanges();
            }

            catch (Exception)
            {

                throw;
            }
        }

        public List<Feedback> ListarMeus(Guid id)
        {
            Paciente pacientef = _clinicContext.Paciente.Find(id)!;
            List<Feedback> list = new List<Feedback>();

            foreach (Feedback feedback in _clinicContext.Feedback)
            {
                if (feedback.Consulta!.IdPaciente == pacientef.IdPaciente)
                {
                    list.Add(feedback);
                }
            }
            return list;
        }

        public List<Feedback> ListarTodos()
        {
            return _clinicContext.Feedback.ToList();
        }
    }
}
