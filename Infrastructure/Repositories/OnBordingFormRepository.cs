using Domain.Models;
using Domain.Models.Enums;
using Domain.ViewModels;
using Infrastructure.Interfaces;
using OnBoarding.ViewModels;
using System;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class OnBordingFormRepository : IOnBordingFormRepository
    {
        private readonly IBaseDataAccess baseDataAccess;

        public OnBordingFormRepository(IBaseDataAccess baseDataAccess)
        {
            this.baseDataAccess = baseDataAccess;
        }

        public async Task<IEnumerable<OnBoardingFormVM>> GetNewHireForms(dynamic parameters)
        {
            return await baseDataAccess.LoadDataAsync<OnBoardingFormVM, dynamic>(nameof(StoreProcedures.GetNewHireForms), parameters, CommandType.StoredProcedure);
        }

        public async Task<OnBoardingFormVM> GetNewHireFormById(dynamic parameters)
        {
            return await baseDataAccess.QuerySingleAsync<OnBoardingFormVM, dynamic>(nameof(StoreProcedures.GetNewHireFormById), parameters, CommandType.StoredProcedure);
        }

        public async Task<bool> SaveNewHireForm(dynamic parameters)
        {
            var rowsAffected = await baseDataAccess.SaveDataAsync<dynamic>(nameof(StoreProcedures.SaveNewHireForm), parameters, CommandType.StoredProcedure);
            return rowsAffected;
        }
        public async Task<bool> ValidateEmployeeCredential(dynamic parameters)
        {
            return await baseDataAccess.QuerySingleAsync<bool, dynamic>(nameof(StoreProcedures.ValidateEmployeeCredential), parameters, CommandType.StoredProcedure);
        }

        public async Task<Employee> GetEmployeeById(dynamic parameters)
        {
            return await baseDataAccess.QuerySingleAsync<Employee, dynamic>(nameof(StoreProcedures.GetEmployeeById), parameters, CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await baseDataAccess.LoadDataAsync<Employee, dynamic>(nameof(StoreProcedures.GetEmployees), new {}, CommandType.StoredProcedure);
        }

        public async Task<bool> SaveBusinessUnit(dynamic parameters)
        {
            var rowsAffected = await baseDataAccess.SaveDataAsync(nameof(StoreProcedures.SaveBusinessUnit), parameters, CommandType.StoredProcedure);
            return rowsAffected;
        }

        public async Task<IEnumerable<TitleBusniessUnit>> GetBusinessUnits(dynamic parameters)
        {
            return await baseDataAccess.LoadDataAsync<TitleBusniessUnit, dynamic>(nameof(StoreProcedures.GetBusinessUnits), parameters, CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<string>> GetEmployeePermissions(dynamic parameters)
        {
            return await baseDataAccess.LoadDataAsync<string, dynamic>(nameof(StoreProcedures.GetEmployeePermissions), parameters, CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<FormDueSectionVM>> GetLeaderSectionDay1TO5()
        {
            return await baseDataAccess.LoadDataAsync<FormDueSectionVM, dynamic>(nameof(StoreProcedures.GetLeaderSectionDay1TO5), new { }, CommandType.StoredProcedure);
        } 
        
        public async Task<IEnumerable<FormDueSectionVM>> GetTrainerSectionDay1TO5()
        {
            return await baseDataAccess.LoadDataAsync<FormDueSectionVM, dynamic>(nameof(StoreProcedures.GetTrainerSectionDay1TO5), new { }, CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<FormDueSectionVM>> GetCheckInAndFollowUpDueSections(dynamic parameters)
        {
            return await baseDataAccess.LoadDataAsync<FormDueSectionVM, dynamic>(nameof(StoreProcedures.GetCheckInAndFollowUpDueSections), parameters, CommandType.StoredProcedure);
        }

    }
}
