using System.Data.SqlClient;

namespace LocadoraDeVeiculos.Infra.Compartilhado
{
    public class DB
    {
        private const string enderecoBanco = @"Data Source=(LocalDB)\MSSqlLocalDB;
                                              Initial Catalog=LocadoraVeiculosTestes.Db;Integrated Security=True";

        public static void executarSql(string comando)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand Comando = new SqlCommand(comando, conexaoComBanco);

            conexaoComBanco.Open();
            Comando.ExecuteNonQuery();
            conexaoComBanco.Close();

        }
    }
}
