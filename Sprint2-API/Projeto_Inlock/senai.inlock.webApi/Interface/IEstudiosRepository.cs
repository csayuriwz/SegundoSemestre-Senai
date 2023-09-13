using senai.inlock.webApi_.Domain;

namespace senai.inlock.webApi_.Interface
{
    public interface IEstudiosRepository
    {

        //CRUD
        List<EstudiosDomain> ListaEstudios();

        void Cadastrar(EstudiosDomain novoEstudio);

        void Deletar(int id);





    }
}
