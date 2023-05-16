namespace Domain.Models
{
    public class Trainer
    {
        public Trainer()
        {
            Id = new Guid().ToString();
        }
        public string Id { get; set; }
        public string? FormId { get; set; }
        public string? Expectetions { get; set; }
        public string? KeyAccomplishment1 { get; set; }
        public string? KeyAccomplishment2 { get; set; }
        public string? KeyAccomplishment3 { get; set; }
        public string? QuickOpportunities { get; set; }
        public string? CurrentAtmosphere { get; set; }
        public string? AdditionalResources { get; set; }
        public string? Skills { get; set; }
        public string? Styles { get; set; }
    }
}
