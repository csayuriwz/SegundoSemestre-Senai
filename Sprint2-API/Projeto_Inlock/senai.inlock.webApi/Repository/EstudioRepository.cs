using senai.inlock.webApi_.Domain;
using senai.inlock.webApi_.Interface;
using System.Data.SqlClient;

namespace senai.inlock.webApi_.Repository
{
    public class EstudioRepository : IEstudiosRepository
    {
        private string StringConexao = "Data Source = NOTE13-S15; Initial catalog = inlock_games_Tarde; User Id = sa; Pwd = Senai@134";

        //EXTRA DESAFIO (Em andamento)
       

        public void Cadastrar(EstudiosDomain novoEstudio)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO Estudio (Nome) VALUES (@Nome)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("Nome", novoEstudio.Nome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
            public List<EstudiosDomain> ListaEstudios()
            {
            List<EstudiosDomain> ListaEstudio = new List<EstudiosDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string? queryLista = "Select Estudio.IdEstudio, Estudio.Nome From Estudio";

                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryLista, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EstudiosDomain estudio = new EstudiosDomain()
                        {
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                            Nome = rdr["Nome"].ToString()
                        };

                        ListaEstudio.Add(estudio);
                    }
                }
            }
            return ListaEstudio;
        }

         public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = "DELETE FROM Estudio WHERE IdEstudio = @IdEstudio";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@IdEstudio", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
