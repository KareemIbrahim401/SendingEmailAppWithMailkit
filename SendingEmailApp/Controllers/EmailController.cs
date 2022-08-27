﻿using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using System.Net;

namespace SendingEmailApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [HttpPost]
        public IActionResult SendEmail(string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("kareemgaming401@gmail.com"));
            email.To.Add(MailboxAddress.Parse("alhassenhamdy@gmail.com"));
            email.Subject = "subject";
            email.Body = new TextPart(TextFormat.Html) { Text = body };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);        
            smtp.Authenticate("kareemgaming401@gmail.com", "vckpomrdmeeynnxz");
            smtp.Send(email);
            smtp.Disconnect(true);

            return Ok();
        }
    }
}
