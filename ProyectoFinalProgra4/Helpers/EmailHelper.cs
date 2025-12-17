using System.Net;
using System.Net.Mail;

namespace ProyectoFinalProgra4.Helpers
{
    public static class EmailHelper
    {
        public static void SendEmail(string to, string subject, string body)
        {
            using (var client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.Credentials = new NetworkCredential("garbanzopicadomichaeljared@gmail.com", "pttc rvwe vhqn jjjc");
                client.EnableSsl = true;

                var mail = new MailMessage("garbanzopicadomichaeljared@gmail.com", to, subject, body);
                client.Send(mail);
            }
        }
    }
}


