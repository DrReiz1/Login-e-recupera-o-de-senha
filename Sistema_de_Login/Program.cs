    using Sistema_de_Login;

        TelaLogin tela = new TelaLogin();

        while (true)
        {
            Console.WriteLine("\n1 - Cadastrar");
            Console.WriteLine("2 - Login");
            Console.WriteLine("0 - Sair");

            string op = Console.ReadLine() ?? "";

            if (op == "1")
            {
                Console.Write("Nome: ");
                string nome = Console.ReadLine() ?? "";

                Console.Write("Email: ");
                string email = Console.ReadLine() ?? "";

                Console.Write("Senha: ");
                string senha = Console.ReadLine() ?? "";

                Console.Write("Data nascimento (dd/MM/yyyy): ");
                string dataStr = Console.ReadLine() ?? "";

                DateTime data;

                if (!DateTime.TryParse(dataStr, out data))
                {
                    Console.WriteLine("Data inválida.");
                    return;
                }

                Usuario.CadastrarUsuario(nome, email, senha, data);
                Console.WriteLine("Usuário cadastrado!");
            }

            else if (op == "2")
            {
                tela.Login();
            }

            else if (op == "0")
                break;
}
