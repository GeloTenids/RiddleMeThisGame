using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiddleMeThisBL
{
    public class smtpRiddleService
    {
        SmtpClient client;
        public smtpRiddleService()
        {
            client = new SmtpClient();
            client.Connect("sandbox.smtp.mailtrap.io", 2525, MailKit.Security.SecureSocketOptions.StartTls);
            client.Authenticate("f2e547fa3d4428", "fd0e08870dd772");
        }
        public bool AddRiddle(string question, string answer)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("TheDiddler", "do-not-reply@Diddler.com"));
            message.To.Add(new MailboxAddress("RiddleAdmin", "Admin@Riddle.com"));
            message.Subject = "New Riddle!";

            message.Body = new TextPart("html")
            {
                Text = "<h1>Good Day, Admin :)</h1>" +
                "<p>New Riddle Added</p>" +
                "<p>Riddle: "+question+"</p>"+
                "<p>Answer: " + answer + ".</p>" +
                "<p><strong><center>--RiddleAdmin--<center></strong></p>"
            };
            try
            {
                client.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                client.Disconnect(true);
            }
        }
        public bool DeleteRiddle(int number)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("TheDiddler", "do-not-reply@Diddler.com"));
            message.To.Add(new MailboxAddress("RiddleAdmin", "Admin@Riddle.com"));
            message.Subject = "Riddle Deleted!";

            message.Body = new TextPart("html")
            {
                Text = "<h1>Good Day, Admin :)</h1>" +
                "<p>Riddle number: <b>" + number + "</b> is removed from the database.</p>" +
                "<p><strong><center>--RiddleAdmin--<center></strong></p>"
            };
            try
            {
                client.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                client.Disconnect(true);
            }
        }
        public bool UpdateRiddle(string question, string answer)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("TheDiddler", "do-not-reply@Diddler.com"));
            message.To.Add(new MailboxAddress("RiddleAdmin", "Admin@Riddle.com"));
            message.Subject = "Riddle Updated!";

            message.Body = new TextPart("html")
            {
                Text = "<h1>Good Day, Admin :)</h1>" +
                "<p>Riddle: " + question + "</p>" +
                "<p>Answer: " + answer + "</p>" +
                "<p>has been updated.</p>" +
                "<p><strong><center>--RiddleAdmin--<center></strong></p>"
            };
            try
            {
                client.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                client.Disconnect(true);
            }
        }
    }
}
