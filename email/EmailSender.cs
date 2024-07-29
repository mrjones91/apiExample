using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace email;

//simple class that implements the IEmailSender class for sending emails.
//We're just calling the SendEmailAsync method so that we can send emails and do whatever else we may need to do
	public class EmailSender : IEmailSender
	{
        public string SendGridSecret { get; set; }
        public EmailSender(IConfiguration _config) //can be configured differently. potentially only slightly more secure than just passing the string
        {
			SendGridSecret = _config.GetValue<string>("SendGrid:SecretKey");
        }

		public async Task SendEmailAsync(string email, string subject, string htmlMessage)
		{
            var client = new SendGridClient(SendGridSecret);
			var from = new EmailAddress("dj@code-crew.org", "DJ"); //should match your sender account on Sendgrid
			var to = new EmailAddress(email);
			var msg = MailHelper.CreateSingleEmail(from, to, subject, "", htmlMessage);
           
			var response = await client.SendEmailAsync(msg);
            Console.WriteLine(response.Body);

            return;
		}
	}