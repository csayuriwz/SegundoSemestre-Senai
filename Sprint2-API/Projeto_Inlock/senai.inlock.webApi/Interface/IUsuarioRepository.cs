using senai.inlock.webApi_.Domain;

namespace senai.inlock.webApi_.Interface
{
    public interface IUsuarioRepository
    {
        UsuarioDomain Login(string email, string senha);
    }
}
