using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

public class EmailService
{
    private readonly string _smtpServer = "smtp.your-email-provider.com"; // SMTP-сервер
    private readonly int _smtpPort = 587; //  587 для TLS или 465 для SSL
    private readonly string _username = "your-email@example.com"; // Ваш email
    private readonly string _password = "your-email-password"; // Ваш пароль

    public async Task SendEmailAsync(string toEmail, string subject, string body)
    {
        try
        {
            using (var smtpClient = new SmtpClient(_smtpServer, _smtpPort))
            {
                smtpClient.Credentials = new NetworkCredential(_username, _password);
                smtpClient.EnableSsl = true; //  SSL, если требуется

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_username),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true //  true, если тело письма в формате HTML
                };

                mailMessage.To.Add(toEmail);

                await smtpClient.SendMailAsync(mailMessage);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при отправке письма: {ex.Message}");
        }
    }
}
