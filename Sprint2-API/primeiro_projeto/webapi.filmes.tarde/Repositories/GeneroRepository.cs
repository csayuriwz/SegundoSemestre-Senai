using System.Data.SqlClient;
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

        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public void atualizarIdUrl(int id, GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
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


                using(SqlCommand cmd = new SqlCommand( queryInsert,con))
                {
                    cmd.Parameters.AddWithValue("@Nome", novoGenero.Nome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = $"DELETE FROM Genero WHERE Genero.IdGenero LIKE {id}";


                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
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
           List<GeneroDomain>ListaGeneros = new List<GeneroDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a instrucao a ser executada (select nesse caso)
               string querySelectAll= "SELECT IdGenero, Nome FROM Genero";


                //Abre a conexao com o banco de dados
                con.Open();

                //declara o SqlDataReader para percorrer(LER) a tabela no bd
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll,con))
                {
                    rdr = cmd.ExecuteReader();

                    //enquanto houver registros para serem lidos no rdr o laco se repetira
                    while(rdr.Read()) 
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
