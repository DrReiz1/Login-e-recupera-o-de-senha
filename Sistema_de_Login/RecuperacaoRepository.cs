using MySql.Data.MySqlClient;
using Sistema_de_Login;
public class RecuperacaoRepository
{
    public static void SalvarToken(string email, string token)
    {
        using var conn = Db.GetConnection();
        conn.Open();

        string sql = @"INSERT INTO recuperacao_senha (Email, Token, ExpiraEm)
                       VALUES (@Email, @Token, @Expira)";

        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@Email", email);
        cmd.Parameters.AddWithValue("@Token", token);
        cmd.Parameters.AddWithValue("@Expira", DateTime.Now.AddMinutes(15));

        cmd.ExecuteNonQuery();
    }
}
