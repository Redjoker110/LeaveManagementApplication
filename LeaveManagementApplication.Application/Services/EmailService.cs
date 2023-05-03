using LeaveManagementApplication.Application.ViewModels.Email;
using Microsoft.Extensions.Options;
using MimeKit;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace LeaveManagementApplication.Application.Services;

public interface IEmailService
{
    Task<int> SendEmailAsync(EmailMessageModel model);
}

public class EmailService : IEmailService
{
    private readonly EmailSettingsModel _emailConfig;

    public EmailService(IOptions<EmailSettingsModel> emailConfig)
    {
        _emailConfig = emailConfig.Value;
    }

    public async Task<int> SendEmailAsync(EmailMessageModel model)
    {
        var emailSent = 0;
        var client = new SendGridClient(_emailConfig.ApiKey);
        var emailMessage = CreateMessage(model);
        var response = await client.SendEmailAsync(emailMessage);

        if (response.IsSuccessStatusCode) emailSent = 1;

        return emailSent;
    }

    private SendGridMessage CreateMessage(EmailMessageModel model)
    {
        var emailMessage = new SendGridMessage();
        var toEmailAddress = new List<EmailAddress>();
        toEmailAddress.AddRange(model.To.Select(x => new EmailAddress(x)));

        emailMessage.AddTos(toEmailAddress);
        emailMessage.From = new EmailAddress(_emailConfig.fromAddress, _emailConfig.fromName);
        emailMessage.Subject = model.Subject;

        var bodyBuilder = new BodyBuilder
            { HtmlBody = string.Format("<h2 style='color:black;'>{0}</h2>", model.Content) };

        if (model.Attachments != null && model.Attachments.Any())
        {
            byte[] fileBytes;

            foreach (var attachment in model.Attachments)
            {
                using (var ms = new MemoryStream())
                {
                    attachment.CopyTo(ms);
                    fileBytes = ms.ToArray();
                }

                bodyBuilder.Attachments.Add(attachment.FileName, fileBytes, ContentType.Parse(attachment.ContentType));
            }
        }

        emailMessage.PlainTextContent = model.Content;
        emailMessage.HtmlContent = model.Content;

        // disable tracking settings
        // ref.: https://sendgrid.com/docs/User_Guide/Settings/tracking.html
        emailMessage.SetClickTracking(false, false);
        emailMessage.SetOpenTracking(false);
        emailMessage.SetGoogleAnalytics(false);
        emailMessage.SetSubscriptionTracking(false);

        return emailMessage;
    }
}