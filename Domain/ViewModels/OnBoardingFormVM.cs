using Domain.Models;

namespace OnBoarding.ViewModels
{
    public class OnBoardingFormVM
    {
        public OnBoardingFormVM()
        {
            FormId = Guid.NewGuid().ToString();
        }

        public string FormId { get; }
        public string? TitleBusinessUnitId { get; set; }
        public string? NewHireName { get; set; }
        public string? NewHireId { get; set; }
        public string? LeaderName { get; set; }
        public string? Unit { get; set; }
        public string? LeaderEmail { get; set; }
        public string? LeaderId { get; set; }
        public string? TrainerName { get; set; }
        public string? TrainerEmail { get; set; }
        public string? TrainerId { get; set; }
        public string? NewHiredPhoneNumber { get; set; }
        public string? LeaderPhoneNumber { get; set; }
        public string? TrainerPhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? TitleBusinessUnit { get; set; }
        public string? LeaderKeyAccomplishment1 { get; set; }
        public string? LeaderKeyAccomplishment2 { get; set; }
        public string? LeaderKeyAccomplishment3 { get; set; }
        public string? LeaderQuickOpportunities { get; set; }
        public string? LeaderCurrentAtmosphere { get; set; }
        public string? LeaderExpectedBehaviours { get; set; }
        public string? LeaderExpectetions { get; set; }
        public string? CreticalResourceWho1 { get; set; }
        public string? CreticalResourceWho2 { get; set; }
        public string? CreticalResourceWho3 { get; set; }
        public string? CreticalResourceWho4 { get; set; }
        public string? CreticalResourceHelp1 { get; set; }
        public string? CreticalResourceHelp2 { get; set; }
        public string? CreticalResourceHelp3 { get; set; }
        public string? CreticalResourceHelp4 { get; set; }
        public string? TrainerExpectetions { get; set; }
        public string? TrainerKeyAccomplishment1 { get; set; }
        public string? TrainerKeyAccomplishment2 { get; set; }
        public string? TrainerKeyAccomplishment3 { get; set; }
        public string? TrainerQuickOpportunities { get; set; }
        public string? TrainerCurrentAtmosphere { get; set; }
        public string? AdditionalResources { get; set; }
        public string? Skills { get; set; }
        public string? Styles { get; set; }
        public string? ThirtyDaysFollowUpKeyAccomplishment1 { get; set; }
        public string? ThirtyDaysFollowUpKeyAccomplishment2 { get; set; }
        public string? ThirtyDaysFollowUpKeyAccomplishment3 { get; set; }
        public string? ThirtyDaysFollowUpAchievements { get; set; }
        public string? ThirtyDaysFollowUpNewHiredName { get; set; }
        public DateTime? ThirtyDaysFollowUpNewHiredReadAndAcceptedDate { get; set; }
        public string? ThirtyDaysFollowUpLeaderName { get; set; }
        public DateTime? ThirtyDaysFollowUpLeaderReadAndAcceptedDate { get; set; }
        public string? ThirtyDaysFollowUpTrainerName { get; set; }
        public DateTime? ThirtyDaysFollowUpTrainerReadAndAcceptedDate { get; set; }
        public string? FortyFiveDaysFollowUpKeyAccomplishment1 { get; set; }
        public string? FortyFiveDaysFollowUpKeyAccomplishment2 { get; set; }
        public string? FortyFiveDaysFollowUpKeyAccomplishment3 { get; set; }
        public string? FortyFiveDaysFollowUpAchievements { get; set; }
        public string? FortyFiveDaysFollowUpNewHiredName { get; set; }
        public DateTime? FortyFiveDaysFollowUpNewHiredReadAndAcceptedDate { get; set; }
        public string? FortyFiveDaysFollowUpLeaderName { get; set; }
        public DateTime? FortyFiveDaysFollowUpLeaderReadAndAcceptedDate { get; set; }
        public string? FortyFiveDaysFollowUpTrainerName { get; set; }
        public DateTime? FortyFiveDaysFollowUpTrainerReadAndAcceptedDate { get; set; }
        public string? CheckInNewHiredName { get; set; }
        public DateTime? CheckInNewHiredReadAndAcceptedDate { get; set; }
        public string? CheckInLeaderName { get; set; }
        public DateTime? CheckInLeaderReadAndAcceptedDate { get; set; }
        public string? CheckInTrainerName { get; set; }
        public DateTime? CheckInTrainerReadAndAcceptedDate { get; set; }
        public string? HumanResourcesReviewedBy { get; set; }
        public DateTime? HumanResourcesReviewedDate { get; set; }
        public bool IsCompleted { get; set; }

    }
}
