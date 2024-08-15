using AGENDAMED.Application.DTOs.user.patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Application.Interface.AppServices.user.patient
{
    public interface IUserPatientAppService 
    {
        Task<PatientViewModel> GetById(string id);
        Task<PatientViewModel> GetByEmail(string email);
        Task<PatientViewModel> GetByLoggedUser();
        Task<PatientViewModel> Create(UserCreatePatientViewModel userCreatePatientViewModel);
        Task<PatientViewModel> Edit(string id,UserEditPatientViewModel userEditPatientViewModel);




    }
}
