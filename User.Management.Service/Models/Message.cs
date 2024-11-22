﻿using MimeKit;

namespace User.Management.Service.Models;
public class Message
{
    public List<MailboxAddress> To { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }

    public Message(IEnumerable<string> to, string subject, string content)
    {
        To = new List<MailboxAddress>();
        To.AddRange(to.Select(x => new MailboxAddress("Email", x))); // Use the 'to' parameter here
        Subject = subject; // Corrected assignment
        Content = content; // Corrected assignment
    }
}
