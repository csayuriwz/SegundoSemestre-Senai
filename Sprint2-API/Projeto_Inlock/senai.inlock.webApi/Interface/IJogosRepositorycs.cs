using senai.inlock.webApi_.Domain;

namespace senai.inlock.webApi_.Interface
{
    public interface IJogosRepositorycs
    {
        //cadastrar listra e deletar

        void Cadastrar(JogosDomain novoFilme);

        void Deletar(int id);

        List<JogosDomain> ListarJogos();
    }
}
