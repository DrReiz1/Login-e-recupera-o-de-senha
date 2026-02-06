using Sistema_de_Login;
using MySql.Data.MySqlClient;

public class TelaLogin
{
    private int tentativas = 0;

    public void Login()
    {
        Console.Write("Email: ");
        string email = Console.ReadLine() ?? "";

        if (tentativas >= 2)
        {
            Console.WriteLine("Número máximo de tentativas atingido.");
            RecuperacaoDeAcesso(email);
            return;
        }

        Console.Write("Senha: ");
        string senha = Console.ReadLine() ?? "";

        Usuario? usuario = Usuario.VerificarLogin(email, senha);

        if (usuario != null)
        {
            Console.WriteLine("Login bem-sucedido!");
            tentativas = 0;
        }
        else
        {
            tentativas++;
            Console.WriteLine("Email ou senha incorretos.");
            Console.WriteLine($"Tentativas: {tentativas}/2");

            if (tentativas >= 2)
            {
                Console.WriteLine("Número máximo de tentativas atingido.");
                RecuperacaoDeAcesso(email);
            }
        }
    }

       public void RecuperacaoDeAcesso(string email)
    {
        Console.WriteLine("Enviando e-mail de recuperação...");
        TokenService.EnviarToken(email);
    }




}
