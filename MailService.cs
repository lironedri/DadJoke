using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace GlassixAssignment
{
    class MailService
    {
        private string _host;
        private string _user;
        private string _password;

        public MailService(string host, string user, string password)
        {
            _host = host;
            _user = user;
            _password = password;
        }

        public void SendDadJoke(string joke, string addressee)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient(_host)
                {
                    Credentials = new NetworkCredential(_user, _password)
                };

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress("my@gmail.com"),
                    Body = joke,
                    Subject = "Dad Joke"
                };
                mailMessage.To.Add(addressee);

                smtpClient.Send(mailMessage);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error sending message with exception: " + e.ToString());
            }
        }


    }
}