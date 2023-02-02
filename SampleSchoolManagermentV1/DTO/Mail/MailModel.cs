﻿namespace SampleSchoolManagermentV1.DTO.Mail
{
    public class MailModel
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<IFormFile>? Attachments { get; set; }
    }
}
