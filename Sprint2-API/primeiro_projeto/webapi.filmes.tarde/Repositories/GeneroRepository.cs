using System.Data.SqlClient;
using System.Runtime.Intrinsics.Arm;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    public class GeneroRepository : IGeneroRepository
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
        /// <param name="genero">Objeto com as novas informacoes</param>
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdateIdBody = "UPDATE Genero SET Nome = @Nome WHERE Genero.IdGenero = @IdGenero";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdateIdBody, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", genero.Nome);
                    cmd.Parameters.AddWithValue("@IdGenero", genero.IdGenero);

                    cmd.ExecuteNonQuery();

                }
            }

        }

     

        public void atualizarIdUrl(int id, GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdate = "UPDATE Genero SET Nome = @Nome WHERE IdGenero = @idGenero";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {

                    cmd.Parameters.AddWithValue("@idGenero", id);
                    cmd.Parameters.AddWithValue("@Nome", genero.Nome);

                    cmd.ExecuteNonQuery();

                }

            }
        }


        /// <summary>
        /// Buscar um genero por seu id
        /// </summary>
        /// <param name="id">o id do genero a ser buscado</param>
        /// <returns>objeto encontrado</returns>
        public GeneroDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectById = "SELECT IdGenero, Nome FROM Genero WHERE IdGenero = @IdGenero";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {

                    cmd.Parameters.AddWithValue("@IdGenero", id);
                    con.Open();
                    rdr = cmd.ExecuteReader();

                    //enquanto houver registros para serem lidos no rdr o laco se repetira
                    if (rdr.Read())
                    {
                        GeneroDomain generoBuscado = new GeneroDomain()
                        {
                            //atribui a propriedade IdGenero o valor da primeira coluna da tabela
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),


                            //atribui a propriedade Nome o valor da coluna Nome
                            Nome = rdr["Nome"].ToString()
                        };

                        return generoBuscado;


                    }
                } return null;


            }

        }



        /// <summary>
        /// esse metodo vai cadastrar um novo genero
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Cadastrar(GeneroDomain novoGenero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO Genero(Nome) VALUES(@Nome)";


                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", novoGenero.Nome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Deletar um genero
        /// </summary>
        /// <param name="id">Id Genero a ser deletado</param>
        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = $"DELETE FROM Genero WHERE Genero.IdGenero LIKE {id}";



                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    //cmd.Parameters.AddWithValue("@Nome", novoGenero.Nome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }





        /// <summary>
        /// Lista todos os tipos de objetos do tipo genero
        /// </summary>
        /// <returns>lista de objetos do tipo genero</returns>
        public List<GeneroDomain> ListarTodos()
        {

            //Cria uma lista de generos onde seram armazenados os dados dos generos
            List<GeneroDomain> ListaGeneros = new List<GeneroDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a instrucao a ser executada (select nesse caso)
                string querySelectAll = "SELECT IdGenero, Nome FROM Genero";


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
                        GeneroDomain genero = new GeneroDomain()
                        {
                            //atribui a propriedade IdGenero o valor da primeira coluna da tabela
                            IdGenero = Convert.ToInt32(rdr[0]),


                            //atribui a propriedade Nome o valor da coluna Nome
                            Nome = rdr["Nome"].ToString()
                        };

                        //adiciona o objeto criado dentro da lista
                        ListaGeneros.Add(genero);
                    }

                }

            }
            //retorna a lista de generos
            return ListaGeneros;
        }

    

    }
}
