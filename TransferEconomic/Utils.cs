using System.Net.Mail;
using System.Net;
using Humanizer;
using static Duende.IdentityServer.Models.IdentityResources;
using RestSharp;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace TransferEconomic
{
    public static class Utils
    {
        public static void sendEmail(string toEmail, string bodyTemplate)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(toEmail);
                mail.From = new MailAddress("mariorosas103@hotmail.com");
                mail.Subject = "Confirmacion de reserva";
                mail.Body = bodyTemplate;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("smtp.office365.com", 587);
                
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("mariorosas103@hotmail.com", "Micro1145");
                //gqkwmpplnvyxljpg
                smtp.Send(mail);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static void SendWhatsapp(string messageBody)
        {
            try
            {
                var accountSid = "AC3215d39b66916f302ea3ffbd8c0e1bad";
                var authToken = "df3e822b16ba8c80b4a14c6f1177704e";
                TwilioClient.Init(accountSid, authToken);

                var messageOptions = new CreateMessageOptions(
                    new PhoneNumber("whatsapp:+5219982396905"));
                messageOptions.From = new PhoneNumber("whatsapp:+14155238886");
                messageOptions.Body = messageBody;

                var message = MessageResource.Create(messageOptions);
                Console.WriteLine(message.Body);
            }
            catch (Exception ex)
            {
                var m = ex.Message;
            }
            

            
        }
    }
}

