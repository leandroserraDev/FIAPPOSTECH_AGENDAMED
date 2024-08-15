using AGENDAMED.Application.DTOs.user.patient;
using AGENDAMED.Application.Interface.AppServices.user.patient;
using AGENDAMED.Domain.Interface.Services.loggedUser;
using AGENDAMED.Domain.Interface.Services.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Application.AppServices.user.patient
{
    public class UserPatientAppService : IUserPatientAppService
    {

        private readonly IUserService _userService;
        private readonly ILoggedUserService _loggedUserService;

        public UserPatientAppService(IUserService userService, ILoggedUserService loggedUserService)
        {
            _userService = userService;
            _loggedUserService = loggedUserService;
        }

        public async Task<PatientViewModel> GetByEmail(string id)
        {
            var user = await _userService.GetPatientById(id);

            if(user == null)
            {
                return null;
            }

            return new PatientViewModel(user);
        }

        public async Task<PatientViewModel> GetByLoggedUser()
        {
            var result = await _loggedUserService.LoggedUser();

             return new PatientViewModel(result);
        }

        public async Task<PatientViewModel> GetById(string id)
        {
            var result = await _userService.GetPatientById(id);

            return new PatientViewModel(result);
        }

        public async Task<PatientViewModel> Create(UserCreatePatientViewModel userCreatePatientViewModel)
        {
            var result = await _userService.CreatePatient(userCreatePatientViewModel.ToDomain(),userCreatePatientViewModel.Password);

            if (result == null) return null;

            return new PatientViewModel(result);

        }

        public async Task<PatientViewModel> Edit(string id, UserEditPatientViewModel userEditPatientViewModel)
        {
            var result = await _userService.UpdatePatient(userEditPatientViewModel.ToDomain());

            if (result == null) return null;

            return new PatientViewModel(result);
        }
    }
}
