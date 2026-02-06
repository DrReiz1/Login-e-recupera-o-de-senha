
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace Sistema_de_Login
{
    public class Usuario
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }

    public static void CadastrarUsuario(string nome, string email, string senha, DateTime data)
        {
            using var conn = Db.GetConnection();
            conn.Open();

            string sql = @"INSERT INTO usuarios (Nome, Email, Senha, DataNascimento)
                        VALUES (@Nome,@Email,@Senha,@Data)";

            using var cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Nome", nome);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Senha", senha);
            cmd.Parameters.AddWithValue("@Data", data);

        }


        public static Usuario? VerificarLogin(string Email, string Senha)
        {
            using var conn = Db.GetConnection();
            conn.Open();

            string sql = @"SELECT * FROM usuarios
                        WHERE Email = @Email AND Senha = @Senha";

            using var cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Senha", Senha);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Usuario
                {
                    Nome = reader.GetString("Nome"),
                    Email = reader.GetString("Email"),
                    Senha = reader.GetString("Senha"),
                    DataNascimento = reader.GetDateTime("DataNascimento")
                };
            }


            return null;
        }
        public bool VerificarLogin(string senha)
        {
            return this.Senha == senha;
        }

    } 
}