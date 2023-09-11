using senai.inlock.webApi_.Domain;
using senai.inlock.webApi_.Interface;
using System.Data.SqlClient;

namespace senai.inlock.webApi_.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private string StringConexao = "Data Source = NOTE13-S15; Initial catalog = inlock_games_Tarde; User Id = sa; Pwd = Senai@134";

        public UsuarioDomain Login(string email, string senha)
        {

            using (SqlConnection con = new SqlConnection(StringConexao))
            {

                string queryLogin = "SELECT IdUsuario, Email,IdTipoUsuario FROM Usuario WHERE Email = @Email AND Senha = @Senha";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryLogin, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain()
                        {
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                            Email = rdr["Email"].ToString(),
                            IdTiposUsuario = Convert.ToInt32(rdr["IdTipoUsuario"])
                        };

                        return usuario;

                    }
                }
                return null;
            }

        }


    }

}

