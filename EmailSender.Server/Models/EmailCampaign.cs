namespace EmailSender.Server.Models
{
    public class EmailCampaign
    {
        public int GroupId { get; set; }
        public string Subject { get; set; } = "";
        public string Message { get; set; } = "";
    }
}
