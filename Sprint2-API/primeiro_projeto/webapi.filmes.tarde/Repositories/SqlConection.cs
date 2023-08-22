namespace webapi.filmes.tarde.Repositories
{
    internal class SqlConection
    {
        private string stringConexao;

        public SqlConection(string stringConexao)
        {
            this.stringConexao = stringConexao;
        }
    }
}