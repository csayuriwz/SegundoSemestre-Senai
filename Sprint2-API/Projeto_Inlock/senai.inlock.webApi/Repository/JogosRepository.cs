﻿using senai.inlock.webApi_.Domain;
using senai.inlock.webApi_.Interface;
using System.Data.SqlClient;

namespace senai.inlock.webApi_.Repository
{
    public class JogosRepository : IJogosRepositorycs
    {

        private string StringConexao = "Data Source = NOTE13-S15; Initial catalog = inlock_games_Tarde; User Id = sa; Pwd = Senai@134";
       
        public void Cadastrar(JogosDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO Jogo(Nome, IdEstudio) VALUES(@Nome, @IdEstudio)";


                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", novoJogo.Nome);
                    cmd.Parameters.AddWithValue("@IdEstudio", novoJogo.IdEstudio);

                    con.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = $"DELETE FROM Jogo WHERE Jogo.IdJogo LIKE {id}";



                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    //cmd.Parameters.AddWithValue("@Nome", novoGenero.Nome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogosDomain> ListarJogos()
        {
            List<JogosDomain> ListaJogos = new List<JogosDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {

                string querySelectAll = "SELECT Jogo.IdJogo, Jogo.IdEstudio, Jogo.Nome,Jogo.Descricao, Jogo.DataLancamento, Jogo.Valor, Estudio.Nome FROM Jogo INNER JOIN Estudio ON Jogo.IdEstudio LIKE Estudio.IdEstudio";


                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogosDomain jogos = new JogosDomain()
                        {

                            IdJogos = Convert.ToInt32(rdr["IdJogo"]),

                            Nome = rdr["Nome"].ToString(),

                            Descricao= rdr["Descricao"].ToString(),

                            DataLancamento = Convert.ToDateTime(rdr["DataLancamento"]),

                            Valor = Convert.ToDecimal(rdr["Valor"]),
                           
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),

                            Estudio = new EstudiosDomain()
                            {
                                IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                                Nome = rdr["Nome"].ToString(),
                            }
                        };


                        ListaJogos.Add(jogos);
                    }

                }

            }

            return ListaJogos;
        }
    }
}
