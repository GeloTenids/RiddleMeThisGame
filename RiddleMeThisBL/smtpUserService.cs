using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;

namespace RiddleMeThisBL
{
    public class smtpUserService
    {
        SmtpClient client;
        public smtpUserService()
        {
            client = new SmtpClient();
            client.Connect("sandbox.smtp.mailtrap.io", 2525, MailKit.Security.SecureSocketOptions.StartTls);
            client.Authenticate("f2e547fa3d4428", "fd0e08870dd772");
        }
        public bool AddUser(string user) 
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("TheDiddler", "do-not-reply@Diddler.com"));
            message.To.Add(new MailboxAddress("RiddleAdmin", "Admin@Riddle.com"));
            message.Subject = "New User!";

            message.Body = new TextPart("html")
            {
                Text = "<h1>Good Day, Admin :)</h1>" +
                "<p>User: <b>"+user+"</b> is added to the database.</p>" +
                "<p><strong>RiddleAdmin</strong></p>"
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
        public bool DeleteUser(string user)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("TheDiddler", "do-not-reply@Diddler.com"));
            message.To.Add(new MailboxAddress("RiddleAdmin", "Admin@Riddle.com"));
            message.Subject = "Deleted User!";

            message.Body = new TextPart("html")
            {
                Text = "<h1>Good Day, Admin :)</h1>" +
                "<p>User: <b>" + user + "</b> is removed in the database.</p>" +
                "<p><strong>RiddleAdmin</strong></p>"
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
        public bool UpdateUser(string user, int score)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("TheDiddler", "do-not-reply@Diddler.com"));
            message.To.Add(new MailboxAddress("RiddleAdmin", "Admin@Riddle.com"));
            message.Subject = "User Score Update!";

            message.Body = new TextPart("html")
            {
                Text = "<h1>Good Day, Admin :)</h1>" +
                "<p>User: <b>" + user + "</b> now has a score of <b>"+score+"</b>!</p>" +
                "<p><strong>RiddleAdmin</strong></p>"
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
