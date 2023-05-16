using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CheckIn
    {
        public CheckIn()
        {
            Id = new Guid().ToString();
        }
        public string Id { get; set; }
        public string? FormId { get; set; }
        public string? NewHiredName { get; set; }
        public DateOnly? NewHiredReadAndAcceptedDate { get; set; }
        public string? LeaderName { get; set; }
        public DateOnly? LeaderReadAndAcceptedDate { get; set; }
        public string? TrainerName { get; set; }
        public DateOnly? TrainerReadAndAcceptedDate { get; set; }
        public string? HumanResourcesReviewedBy { get; set; }
        public DateOnly? HumanResourcesReviewedDate { get; set; }
    }
}
