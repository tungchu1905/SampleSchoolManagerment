
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using SampleSchoolManagermentV1.DTO.Mail;

namespace SampleSchoolManagermentV1.EmailService
{
    public class MailService : IMailService
    {
        //private static Random random = new Random();
        private readonly MailSettings _mailSettings;
        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public async Task SendEmailAsync(MailModel mailModel)
        {
            //const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            //string ss = new string(Enumerable.Repeat(chars, 10)
            //    .Select(s => s[random.Next(s.Length)]).ToArray());
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(mailModel.ToEmail));
            email.Subject = mailModel.Subject;
            var builder = new BodyBuilder();
            if (mailModel.Attachments != null)
            {
                byte[] fileBytes;
                foreach (var file in mailModel.Attachments)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    }
                }
            }
            builder.HtmlBody = mailModel.Body;
            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Mail, _mailSettings.appPassword);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }

    }
}
