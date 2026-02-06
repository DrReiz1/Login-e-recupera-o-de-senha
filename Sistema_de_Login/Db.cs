using MySql.Data.MySqlClient;

namespace Sistema_de_Login
{
    public static class Db
    {
        public static string ConnStr =
            "server=localhost;user=root;password=;database=sistema_login";

             public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnStr);
        }
    }
}