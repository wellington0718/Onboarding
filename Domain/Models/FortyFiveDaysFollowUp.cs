namespace Domain.Models
{
    public class FortyFiveDaysFollowUp
    {
        public FortyFiveDaysFollowUp()
        {
            Id = new Guid().ToString();
        }
        public string Id { get; set; }
        public string? FormId { get; set; }
        public string? KeyAccomplishment1 { get; set; }
        public string? KeyAccomplishment2 { get; set; }
        public string? KeyAccomplishment3 { get; set; }
        public string? Achievements { get; set; }
        public string? NewHiredName { get; set; }
        public DateOnly? NewHiredReadAndAcceptedDate { get; set; }
        public string? LeaderName { get; set; }
        public DateOnly? LeaderReadAndAcceptedDate { get; set; }
        public string? TrainerName { get; set; }
        public DateOnly? TrainerReadAndAcceptedDate { get; set; }
    }
}
