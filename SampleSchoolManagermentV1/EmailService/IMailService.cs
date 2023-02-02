
using SampleSchoolManagermentV1.DTO.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleSchoolManagermentV1.EmailService
{
    public interface IMailService
    {
        Task SendEmailAsync(MailModel mailModel);
    }
}
