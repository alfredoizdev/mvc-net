using portafolio.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace portafolio.Services;

public interface IServiceEmail {
	Task Sending(ContactViewModel contact);
}

public class ServiceEmailSendGrid:IServiceEmail {

	private readonly IConfiguration configuration;
	public ServiceEmailSendGrid(IConfiguration configuration) {
		this.configuration = configuration;
	}

	public async Task Sending(ContactViewModel contact) {
		var apiKey = configuration.GetValue<String>("SENDGRID_API_KEY");
		var email = configuration.GetValue<String>("SENDGRID_FROM");
		var name = configuration.GetValue<String>("SENDGRID_NAME");

		var client = new SendGridClient(apiKey);
		var from = new EmailAddress(email,name);
		var subject = $"The Client {contact.Email} want get in touch";
		var to = new EmailAddress(email,name);
		var messageTextPlane = contact.Message;
		var contentHtml = @$"De: {contact.Name} - 
			Email: {contact.Email}
			Message: {contact.Message}
			";
		var singleEmail = MailHelper.CreateSingleEmail(from,to,subject,messageTextPlane,contentHtml);
		var response = await client.SendEmailAsync(singleEmail);

	}

}