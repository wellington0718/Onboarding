using Domain.Models;
using Domain.ViewModels;
using OnBoarding.ViewModels;

namespace Infrastructure.Interfaces
{
    public interface IOnBordingFormRepository
    {
        public Task<bool> SaveNewHireForm(dynamic parameters);
        public Task<bool> SaveBusinessUnit(dynamic parameters);
        public Task<IEnumerable<OnBoardingFormVM>> GetNewHireForms(dynamic parameters);
        public Task<OnBoardingFormVM> GetNewHireFormById(dynamic parameters);
        public Task<bool> ValidateEmployeeCredential(dynamic parameters);
        public Task<Employee> GetEmployeeById(dynamic parameters);
        public Task<IEnumerable<Employee>> GetEmployees();
        public Task<IEnumerable<TitleBusniessUnit>> GetBusinessUnits(dynamic parameters);
        public Task<IEnumerable<string>> GetEmployeePermissions(dynamic parameters);
        public Task<IEnumerable<FormDueSectionVM>> GetLeaderSectionDay1TO5();
        public Task<IEnumerable<FormDueSectionVM>> GetTrainerSectionDay1TO5();
        public Task<IEnumerable<FormDueSectionVM>> GetCheckInAndFollowUpDueSections(dynamic parameters);
    }
}