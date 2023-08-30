using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    namespace webapi.filmes.tarde.Repositories
    {
        public class FilmeRepository : IFilmeRepository
        {

            /// <summary>
            /// string de conexao com o banco de dados que recebe os seguintes parametros:
            /// Data source: nome dp servidor do banco
            /// Initial Catalogy: Nome do banco de dados
            /// 
            /// Autenticacao
            ///     -windows: Integrated security = true
            ///     sqlserver: UserId=sa; pwd= Senha
            /// </summary>
            private string StringConexao = "Data Source = NOTE13-S15; Initial catalog = Filmes_T; User Id = sa; Pwd = Senai@134";
            private SqlConnection con;

            /// <summary>
            /// Atualizar um genero passando o seu id pelo corpo da requisicao
            /// </summary>
            /// <param name="filme">Objeto com as novas informacoes</param>
            public void AtualizarIdCorpo(FilmeDomain filme)
            {
                using (SqlConnection con = new SqlConnection(StringConexao))
                {
                    string queryUpdateIdBody = "UPDATE Filme SET Titulo = @Titulo WHERE Filme.IdFilme = @IdFilme";

                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(queryUpdateIdBody, con))
                    {
                        cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
                        cmd.Parameters.AddWithValue("@IdFilme", filme.IdFilme);

                        cmd.ExecuteNonQuery();

                    }
                }

            }



            public void atualizarIdUrl(int id, FilmeDomain filme)
            {
                using (SqlConnection con = new SqlConnection(StringConexao))
                {
                    string queryUpdate = "UPDATE Filme SET Titulo = @Titulo WHERE IdFilme = @idFilme";

                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                    {

                        cmd.Parameters.AddWithValue("@idfilme", id);
                        cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);

                        cmd.ExecuteNonQuery();

                    }

                }
            }


            /// <summary>
            /// Buscar um filme por seu id
            /// </summary>
            /// <param name="id">o id do filme a ser buscado</param>
            /// <returns>objeto encontrado</returns>
            public FilmeDomain BuscarPorId(int id)
            {
                using (SqlConnection con = new SqlConnection(StringConexao))
                {
                    string querySelectById = "SELECT IdFilme, Titulo FROM Filme WHERE IdFilme = @IdFilme";

                    SqlDataReader rdr;

                    using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                    {

                        cmd.Parameters.AddWithValue("@IdFilme", id);
                        con.Open();
                        rdr = cmd.ExecuteReader();

                        //enquanto houver registros para serem lidos no rdr o laco se repetira
                        if (rdr.Read())
                        {
                            FilmeDomain filmeBuscado = new FilmeDomain()
                            {
                                //atribui a propriedade IdFilme o valor da primeira coluna da tabela
                                IdFilme = Convert.ToInt32(rdr["IdFilme"]),


                                //atribui a propriedade Titulo o valor da coluna Titulo
                                Titulo = rdr["Titulo"].ToString()
                            };

                            return filmeBuscado;


                        }
                    }
                    return null;


                }

            }



            /// <summary>
            /// esse metodo vai cadastrar um novo filme
            /// </summary>
            /// <exception cref="NotImplementedException"></exception>
            public void Cadastrar(FilmeDomain novoFilme)
            {
                using (SqlConnection con = new SqlConnection(StringConexao))
                {
                    string queryInsert = "INSERT INTO Filme(Titulo, IdGenero) VALUES(@Titulo, @IdGenero)";


                    using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                    {
                        cmd.Parameters.AddWithValue("@Titulo", novoFilme.Titulo);
                        cmd.Parameters.AddWithValue("@IdGenero", novoFilme.IdGenero);

                        con.Open();

                        cmd.ExecuteNonQuery();

                    }
                }
            }


            /// <summary>
            /// Deletar um filme
            /// </summary>
            /// <param name="id">Id Filme a ser deletado</param>
            public void Deletar(int id)
            {
                using (SqlConnection con = new SqlConnection(StringConexao))
                {
                    string queryDelete = $"DELETE FROM Filme WHERE Filme.IdFilme LIKE {id}";



                    using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                    {
                        //cmd.Parameters.AddWithValue("@Nome", novoGenero.Nome);

                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }





            /// <summary>
            /// Lista todos os tipos de objetos do tipo filme
            /// </summary>
            /// <returns>lista de objetos do tipo filme</returns>
            public List<FilmeDomain> ListarTodos()
            {

                //Cria uma lista de filmes onde seram armazenados os dados dos filmes
                List<FilmeDomain> ListaFilmes = new List<FilmeDomain>();

                using (SqlConnection con = new SqlConnection(StringConexao))
                {
                    //Declara a instrucao a ser executada (select nesse caso)
                    string querySelectAll = "SELECT Filme.IdFilme, Filme.Titulo, Genero.IdGenero, Genero.Nome FROM Filme INNER JOIN Genero ON Genero.IdGenero LIKE Filme.IdGenero";

                    //Abre a conexao com o banco de dados
                    con.Open();

                    //declara o SqlDataReader para percorrer(LER) a tabela no bd
                    SqlDataReader rdr;

                    using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                    {
                        rdr = cmd.ExecuteReader();

                        //enquanto houver registros para serem lidos no rdr o laco se repetira
                        while (rdr.Read())
                        {
                            FilmeDomain filme = new FilmeDomain()
                            {
                                //atribui a propriedade IdGenero o valor da primeira coluna da tabela
                                IdFilme = Convert.ToInt32(rdr["IdFilme"]),

                                //atribui a propriedade Titulo o valor da coluna Titulo
                                Titulo = rdr["Titulo"].ToString(),

                                IdGenero = Convert.ToInt32(rdr["IdGenero"]),

                                Genero = new GeneroDomain()
                                {
                                    IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                                    Nome = rdr["Nome"].ToString(),
                                }
                            };

                            //adiciona o objeto criado dentro da lista
                            ListaFilmes.Add(filme);
                        }

                    }

                }
                //retorna a lista de generos
                return ListaFilmes;
            }



        }
    }
}

