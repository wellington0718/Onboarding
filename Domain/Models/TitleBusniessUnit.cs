namespace Domain.Models
{
    public class TitleBusniessUnit
    {
        public TitleBusniessUnit()
        {
            Id = Guid.NewGuid().ToString();
            IsAdding = true;
        }
        public string Id { get; set; }
        public string? Unit { get; set; }
        public string? LeaderId { get; set; }
        public string? Leader { get; set; }
        public string? TrainerId { get; set; }
        public string? Trainer { get; set; }
        public bool IsAdding { get; set; }
    }
}
