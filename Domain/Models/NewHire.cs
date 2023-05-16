namespace Domain.Models
{
    public class NewHire
    {
        public NewHire()
        {
            FormId = Guid.NewGuid().ToString();
        }
        public string? FormId { get; set; }
        public string? NewHireName { get; set; }
        public string? NewHiredPhoneNumber { get; set; }
        public string? LeaderName { get; set; }
        public string? LeaderPhoneNumber { get; set; }
        public string? TrainerName { get; set; }
        public string? TrainerPhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? TitleBusinessUnit { get; set; }
    }
}
