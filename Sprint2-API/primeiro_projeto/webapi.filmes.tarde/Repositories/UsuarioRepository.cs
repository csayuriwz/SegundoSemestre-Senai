using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string StringConexao = "Data Source = NOTE13-S15; Initial catalog = Filmes_T; User Id = sa; Pwd = Senai@134";

        public UsuarioDomain BuscarUsuario(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryLogin = "SELECT IdUsuario, Email, Permissao FROM Usuario WHERER Email = @Email AND Senha = @Senha";

                con.Open();
                using (SqlCommand cmd = new SqlCommand(queryLogin, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if(rdr.Read()) 
                    {
                        UsuarioDomain usuario = new UsuarioDomain()
                        {
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                            Email = rdr["Email"].ToString(),
                            Permissao = rdr["Permissao"].ToString()
                        };

                        return usuario;

                    }

                    return null;
                }
            }
        }

    }
}
