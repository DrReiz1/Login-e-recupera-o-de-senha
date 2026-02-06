using System;
using MySql.Data.MySqlClient;

namespace Sistema_de_Login
{
    public static class TokenService
    {
        public static string GerarToken()
        {
            return Guid.NewGuid().ToString().Substring(0, 6).ToUpper();
        }

        public static void EnviarToken(string email)
        {
            string token = GerarToken();

            using var conn = Db.GetConnection();
            conn.Open();

            string sql = @"UPDATE usuarios 
                           SET Token=@Token, TokenExpira=@Expira
                           WHERE Email=@Email";

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Token", token);
            cmd.Parameters.AddWithValue("@Expira", DateTime.Now.AddMinutes(10));
            cmd.Parameters.AddWithValue("@Email", email);

            cmd.ExecuteNonQuery();

            EmailService.EnviarRecuperacao(email, token);
        }
    }
}
