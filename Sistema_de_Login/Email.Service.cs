    using MailKit.Net.Smtp;
    using MailKit.Security;
    using MimeKit;
    using Sistema_de_Login;
    using MySql.Data.MySqlClient;
    public static class EmailService
    {
        public static void EnviarRecuperacao(string emailDestino, string token)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Sistema", "SEU EMAIL AQUI..."));
        message.To.Add(new MailboxAddress("", emailDestino));
        message.Subject = "Recuperação de senha";

        message.Body = new TextPart("plain")
        {
            Text = $"EU TE AMOOOOOOOOOO MEU BEMMMMMM\n Isso daq é um sistema q desenvolvi no EAD de hoje que serve como se fosse recuperação de senha sabe? olha.... \nSeu token de recuperação é: {token}"
        };

        using var client = new SmtpClient();
        client.Connect("smtp.gmail.com", 587, false);
        client.Authenticate("SEU EMAIL AQUI...", "SUA SENHA APP AQUI...");
        client.Send(message);
        client.Disconnect(true);
    }

    }
