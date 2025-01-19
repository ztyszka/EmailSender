using System.Net.Mail;
using System.Net;
using EmailSender.Server.Models;
using EmailSender.Server.Repositories;
using MimeKit;
using MailKit.Net.Smtp;
using EmailSender.Server.Options;
using Microsoft.Extensions.Options;

namespace EmailSender.Server.Services;

public interface IEmailCampaignService
{
    public Task SendEmailCampain(EmailCampaign campaign);
}

public class EmailCampaignService : IEmailCampaignService
{
    private readonly DbContext _dbContext;
    private readonly EmailCampaignOptions _options;

    public EmailCampaignService(DbContext dbContext, IOptions<EmailCampaignOptions> options)
    {
        _dbContext = dbContext;
        _options = options.Value;
    }

    public async Task SendEmailCampain(EmailCampaign campaign)
    {
        var contacts = await _dbContext.GetEmailsFromGroup(campaign.GroupId);
        
        await SendEmailCampaign(contacts, campaign.Subject, campaign.Message);
    }

    private async Task SendEmailCampaign(List<Contact> contacts, string subject, string message)
        // can be extracted to separate class according to the rule:
        // 'private methods should be public methods of antother class'
        // but I decided to keep it here for code clarity
    {
        using (var smtpClient = new MailKit.Net.Smtp.SmtpClient())
        {
            smtpClient.Connect("smtp.gmail.com", 465, true);
            smtpClient.Authenticate(_options.Email, _options.Password);
            var mailMessage = PrepareMessage(contacts);
            await smtpClient.SendAsync(mailMessage);
            
            smtpClient.Disconnect(true);
        }

        MimeMessage PrepareMessage(List<Contact> contacts)
        {
            var mailMessage = new MimeMessage();
            mailMessage.From.Add(new MailboxAddress(_options.Name, _options.Email));
            foreach (var contact in contacts)
                mailMessage.Bcc.Add(new MailboxAddress(contact.Name, contact.Email));
            // SMTP server probably has some limits of recipents
            // - this solution will work only with limited size of recipents' list
            // for bigger lists using some kind of queue or background service to handle it would be necessary

            mailMessage.Subject = subject;
            mailMessage.Body = new TextPart("plain")
            {
                Text = message
            };

            return mailMessage;
        }
    }
}
