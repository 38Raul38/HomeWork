namespace NetworkLesson4.Models;

public class EmailMessage
{
    public string From { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public string To { get; set; }

    public EmailMessage(string from, string subject, string body, string to)
    {
        From = from;
        Subject = subject;
        Body = body;
        To = to;
    }
    
}