using health_clinic.webapi.Domain;

namespace health_clinic.webapi.Interfaces
{
    public interface IFeedbackRepository
    {
        void Cadastrar(Feedback feedback);

        void Deletar(Guid id);

        void Atualizar(Guid id, Feedback feedback);

        List<Feedback> ListarTodos();

        List<Feedback> ListarMeus(Guid id);
    }
}
