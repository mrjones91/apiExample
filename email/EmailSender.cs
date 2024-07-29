using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace email;

	public class EmailSender : IEmailSender
	{
        public string SendGridSecret { get; set; }
        public EmailSender(IConfiguration _config)
        {
			SendGridSecret = _config.GetValue<string>("SendGrid:SecretKey");
            Console.WriteLine(SendGridSecret);
        }

		public async Task SendEmailAsync(string email, string subject, string htmlMessage)
		{
            var client = new SendGridClient(SendGridSecret);
			var from = new EmailAddress("dj@code-crew.org", "DJ");
			var to = new EmailAddress(email);
			var msg = MailHelper.CreateSingleEmail(from, to, subject, "", htmlMessage);
            Console.Write("From: {0}\n", from.Email);
            Console.Write("TO: {0}\n", to.Email);
			var response = await client.SendEmailAsync(msg);
            Console.WriteLine(response.Body);
            return;
		}
	}