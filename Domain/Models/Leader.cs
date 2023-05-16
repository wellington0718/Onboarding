namespace Domain.Models
{
    public class Leader
    {
        public Leader()
        {
            Id = new Guid().ToString();
        }
        public string Id { get; set; }
        public string? FormId { get; set; }
        public string? KeyAccomplishment1 { get; set; }
        public string? KeyAccomplishment2 { get; set; }
        public string? KeyAccomplishment3 { get; set; }
        public string? QuickOpportunities { get; set; }
        public string? CurrentAtmosphere { get; set; }
        public string? ExpectedBehaviours { get; set; }
        public string? CreticalResourceWho1 { get; set; }
        public string? CreticalResourceWho2 { get; set; }
        public string? CreticalResourceWho3 { get; set; }
        public string? CreticalResourceWho4 { get; set; }
        public string? CreticalResourceHelp1 { get; set; }
        public string? CreticalResourceHelp2 { get; set; }
        public string? CreticalResourceHelp3 { get; set; }
        public string? CreticalResourceHelp4 { get; set; }
        public string? Expectetions { get; set; }
    }
}
