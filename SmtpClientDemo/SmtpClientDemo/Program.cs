using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using NetworkLesson4.Models;

EmailSender emailSender = new();

Console.Write("Enter your email: ");
var sender = Console.ReadLine();

Console.Write("Enter email to send: ");
var recipient = Console.ReadLine();

Console.Write("Enter your subject: ");
var subject = Console.ReadLine();

Console.Write("Enter your body: ");
var body = Console.ReadLine();

var message = new EmailMessage(sender, subject, body, recipient);

emailSender.Send(message);
