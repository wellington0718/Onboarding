namespace Domain.Models
{
    public class Employee
    {
        public string? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? InternalCellphone { get; set; }
        public string? PersonalCellphone { get; set; }
        public string? Email { get; set; }
        public string? TrimmedId => Id?.TrimStart('0');
        public string? CommonName => $"{FirstName?.Split(' ')[0]} {LastName?.Split(' ')[0]}";
        public string? IdCommonName => $"{TrimmedId} - {CommonName}";
    }
}
