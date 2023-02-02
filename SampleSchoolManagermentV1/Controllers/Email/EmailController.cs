
using Microsoft.AspNetCore.Mvc;
using SampleSchoolManagermentV1.DTO.Mail;
using SampleSchoolManagermentV1.EmailService;

namespace SampleSchoolManagermentV1.Controllers.Email
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {

        private readonly IMailService mailService;
        public EmailController(IMailService mailService)
        {
            this.mailService = mailService;
        }
        [HttpPost("sendMail")]
        public async Task<IActionResult> receiveMailPassword([FromForm] MailModel request)
        {
            try
            {
                await mailService.SendEmailAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
