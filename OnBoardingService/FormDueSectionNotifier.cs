using Domain.ViewModels;
using Infrastructure.Email;
using Infrastructure.Interfaces;
using System.Timers;
using Timer = System.Timers.Timer;
namespace OnBoardingService
{
    public class FormDueSectionNotifier
    {
        private readonly Timer _timer;
        private static IOnBordingFormRepository? _onBordingFormRepository;
        public FormDueSectionNotifier(IOnBordingFormRepository onBordingFormRepository)
        {
            _onBordingFormRepository = onBordingFormRepository;
            _timer = new Timer(TimeSpan.FromDays(1).TotalMilliseconds);
            _timer.Elapsed += TimerElapsed;
        }

        private async void TimerElapsed(object? sender, ElapsedEventArgs e)
        {
            await SendEmailNotificationAsync();
        }

        public static async Task SendEmailNotificationAsync()
        {
            try
            {
                if(_onBordingFormRepository is not null)
                {
                     var leaderSection1To5ToComplete = (await _onBordingFormRepository.GetLeaderSectionDay1TO5()).ToList();
                var trainerSection1To5ToComplete = (await _onBordingFormRepository.GetTrainerSectionDay1TO5()).ToList();

                var leaderCheckIn9To10 = (await _onBordingFormRepository.GetCheckInAndFollowUpDueSections(new { Days = "NineToTen", Principal = "Leader" })).ToList();
                var trainerCheckIn9To10 = (await _onBordingFormRepository.GetCheckInAndFollowUpDueSections(new { Days = "NineToTen", Principal = "Trainer" })).ToList();
                var newHireCheckIn9To10 = (await _onBordingFormRepository.GetCheckInAndFollowUpDueSections(new { Days = "NineToTen", Principal = "NewHire" })).ToList();

                var leaderCheckInThirty = (await _onBordingFormRepository.GetCheckInAndFollowUpDueSections(new { Days = "Thirty", Principal = "Leader" })).ToList();
                var trainerCheckInThirty = (await _onBordingFormRepository.GetCheckInAndFollowUpDueSections(new { Days = "Thirty", Principal = "Trainer" })).ToList();
                var newHireCheckInThirty = (await _onBordingFormRepository.GetCheckInAndFollowUpDueSections(new { Days = "Thirty", Principal = "NewHire" })).ToList();

                var leaderCheckInFoirtyFive = (await _onBordingFormRepository.GetCheckInAndFollowUpDueSections(new { Days = "FoirtyFive", Principal = "Leader" })).ToList();
                var trainerCheckInFoirtyFive = (await _onBordingFormRepository.GetCheckInAndFollowUpDueSections(new { Days = "FoirtyFive", Principal = "Trainer" })).ToList();
                var newHireCheckInFoirtyFive = (await _onBordingFormRepository.GetCheckInAndFollowUpDueSections(new { Days = "FoirtyFive", Principal = "NewHire" })).ToList();

                var ThirtyFollowUp = (await _onBordingFormRepository.GetCheckInAndFollowUpDueSections(new { Days = "Thirty", Principal = "FollowUp" })).ToList();
                var FortyFiveFollowUp = (await _onBordingFormRepository.GetCheckInAndFollowUpDueSections(new { Days = "FortyFive", Principal = "FollowUp" })).ToList();

                await SendSectionDueNotification(leaderSection1To5ToComplete, 2, 5, "POSITION EXPECTATIONS FROM THE LEADER (DAY 1-5)");
                await SendSectionDueNotification(trainerSection1To5ToComplete, 2, 5, "POSITION EXPECTATIONS FROM THE TRAINER (DAY 1-5)");

                await SendSectionDueNotification(leaderCheckIn9To10, 3, 10, "CHECK-IN APPOINTMENTS ACKNOWLEDGEMENTS (DAYS 9-10)");
                await SendSectionDueNotification(trainerCheckIn9To10, 3, 10, "CHECK-IN APPOINTMENTS ACKNOWLEDGEMENTS (DAYS 9-10)");
                await SendSectionDueNotification(newHireCheckIn9To10, 3, 10, "CHECK-IN APPOINTMENTS ACKNOWLEDGEMENTS (DAYS 9-10)");

                await SendSectionDueNotification(leaderCheckInThirty, 5, 30, "CHECK-IN AT 30 APPOINTMENTS ACKNOWLEDGEMENTS");
                await SendSectionDueNotification(trainerCheckInThirty, 5, 30, "CHECK-IN AT 30 APPOINTMENTS ACKNOWLEDGEMENTS");
                await SendSectionDueNotification(newHireCheckInThirty, 5, 30, "CHECK-IN AT 30 APPOINTMENTS ACKNOWLEDGEMENTS");

                await SendSectionDueNotification(leaderCheckInFoirtyFive, 7, 45, "CHECK-IN AT 45 APPOINTMENTS ACKNOWLEDGEMENTS");
                await SendSectionDueNotification(trainerCheckInFoirtyFive, 7, 45, "CHECK-IN AT 45 APPOINTMENTS ACKNOWLEDGEMENTS");
                await SendSectionDueNotification(newHireCheckInFoirtyFive, 7, 45, "CHECK-IN AT 45 APPOINTMENTS ACKNOWLEDGEMENTS");

                await SendSectionDueNotification(ThirtyFollowUp, 5, 30, "30 DAY FOLLOW-UP");
                await SendSectionDueNotification(FortyFiveFollowUp, 7, 45, "45 DAY FOLLOW-UP");
                }
               
            }
            catch (Exception e)
            {
                File.WriteAllText("C:\\OnBoarding\\ServiceLogs\\logs.txt", e.Message);
            }
        }

        private static async Task SendSectionDueNotification(List<FormDueSectionVM> sectionsDue, int module, int daysBeforeDue, string section)
        {
            if (sectionsDue.Any())
            {
                foreach (var sectionDue in sectionsDue)
                {
                    var currentDate = DateTime.Now.Date;
                    var sectionDueDate = sectionDue.CreatedDate.AddDays(daysBeforeDue).Date;
                    var sectionCreatedDate = sectionDue.CreatedDate.Date;

                    if (currentDate <= sectionDueDate)
                    {
                        if ((currentDate - sectionCreatedDate).Days % module == 0 || currentDate == sectionDueDate)
                        {
                            EmailSettings.SetSettings();
                            var content = CreateEmailTemplate(sectionDue.FormId, sectionDue.NewHireName, section);
                            await Mailer.SendWithGraph("wmunoz@synergiescorp.com", "Onboarding form", content, EmailSettings.Signature);
                        }
                    }
                }
            }
        }

        private static string CreateEmailTemplate(string formId, string newHireName, string dueSection)
        {
            return File.ReadAllText(EmailSettings.BodyTemplate)
             .Replace("_section_", dueSection)
             .Replace("_newHire_", newHireName)
             .Replace("_formId_", formId);
        }

        public void Stop()
        {
            _timer.Stop();
        }

        public void Start()
        {
            _timer.Start();
        }

    }
}
