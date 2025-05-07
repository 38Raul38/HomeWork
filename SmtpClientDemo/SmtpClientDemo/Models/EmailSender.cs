namespace NetworkLesson4.Models;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

public class EmailSender
{
    public bool Send(EmailMessage emailMessage)
    {
        try
        {
            var configBuilder = new ConfigurationBuilder();

            configBuilder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var config = configBuilder.Build();

            var smtpHost = config["Smtp:Host"];
            var smtpPort = config["Smtp:Port"];
            var smtpUser = config["Smtp:Username"];
            var smtpPassword = config["Smtp:Password"];

            using var smtpClient = new SmtpClient(smtpHost, int.Parse(smtpPort))
            {
                Credentials = new NetworkCredential(smtpUser, smtpPassword),
                EnableSsl = true,
            };

            using var message = new MailMessage(emailMessage.From, emailMessage.To, emailMessage.Subject,
                emailMessage.Body);

            smtpClient.Send(message);
            Console.WriteLine("Message Sended!!");
            return true;
        }
        
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to send email: {ex.Message}");
            return false;
        }
    }
}