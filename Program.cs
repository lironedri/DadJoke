using System;
using System.Net;
using System.Net.Http;
using System.Net.Mail;

namespace GlassixAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Hello! What is your email address?");
                string emailAddress = Console.ReadLine();

                ValidateEmail validateEmail = new ValidateEmail("https://disify.com/api/email/");
                bool isValidEmail = validateEmail.IsValid(emailAddress);
                if (isValidEmail == false)
                {
                    Console.WriteLine("The email address inserted is not valid");
                    return;
                }

                RandomJoke randomJoke = new RandomJoke("https://icanhazdadjoke.com/slack");
                string joke = randomJoke.GetJoke();

                MailService mailService = new MailService("glassix-hmail.westeurope.cloudapp.azure.com", "test@glassix-spam.com", "G1uJyBnLV7rw");
                mailService.SendDadJoke(joke, emailAddress);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }
}
