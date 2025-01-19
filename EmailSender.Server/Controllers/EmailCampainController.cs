using EmailSender.Server.Models;
using EmailSender.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmailSender.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailCampaignController: ControllerBase
    {
        private IEmailCampaignService _campaignService;
        public EmailCampaignController(IEmailCampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        [HttpPost]
        public async Task SendEmailCampain([FromBody] EmailCampaign campaign)
        {
            await _campaignService.SendEmailCampain(campaign);
        }
    }
}
