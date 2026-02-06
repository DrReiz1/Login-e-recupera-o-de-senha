using Sistema_de_Login;
using MySql.Data.MySqlClient;

public class ResetSenha
{
    public static void Redefinir()
    {
        Console.Write("Email: ");
        string email = Console.ReadLine() ?? "";

        Console.Write("Token recebido: ");
        string token = Console.ReadLine() ?? "";

        Console.Write("Nova senha: ");
        string novaSenha = Console.ReadLine() ?? "";

        using var conn = Db.GetConnection();
        conn.Open();

        string sql = @"SELECT * FROM usuarios 
                       WHERE Email=@Email 
                       AND Token=@Token 
                       AND TokenExpira > NOW()";

        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@Email", email);
        cmd.Parameters.AddWithValue("@Token", token);

        using var reader = cmd.ExecuteReader();

        if (!reader.Read())
        {
            Console.WriteLine("Token inválido ou expirado.");
            return;
        }

        reader.Close();

        string update = @"UPDATE usuarios 
                          SET Senha=@Senha, Token=NULL 
                          WHERE Email=@Email";

        using var cmd2 = new MySqlCommand(update, conn);
        cmd2.Parameters.AddWithValue("@Senha", novaSenha);
        cmd2.Parameters.AddWithValue("@Email", email);

        cmd2.ExecuteNonQuery();

        Console.WriteLine("Senha redefinida com sucesso!");
    }
}
