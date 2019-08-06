using HIMS.BL.Models;
using Email.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace Email.Services
{
    public class EmailService : IEmailService
    {
        private EmailAddress Email;
        private SendGridClient Client;

        private const string _layoutHtml =
            "<div style=\"margin-top: 20px;\">Welcome! Now, you are in a team,</div>" +
            "<div>Dev Incubator Inc.</div>";


        public EmailService(string apiKey, string email)
        {
            Email = new EmailAddress(email, "Dev Incubator Inc.");
            Client = new SendGridClient(apiKey);
        }
        public async Task MessageToUserAsync(UserDTO user, string subject, string html)
        {
            var to = new EmailAddress(user.Email, $"{user.Name}");

            var htmlContent = "<div>" + html + _layoutHtml + "</div>";

            var msg = MailHelper.CreateSingleEmail(Email, to, subject, "Confirmation", htmlContent);

            await Client.SendEmailAsync(msg);
        }

        public async Task MessageToUserAsync(IEnumerable<UserDTO> users, string subject, string html)
        {
            foreach (var user in users)
            {
                await MessageToUserAsync(user, subject, html);
            }
        }
    }
}
