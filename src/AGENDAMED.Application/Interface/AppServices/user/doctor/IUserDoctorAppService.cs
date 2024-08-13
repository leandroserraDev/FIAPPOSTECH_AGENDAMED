using AGENDAMED.Application.DTOs.user;
using AGENDAMED.Application.DTOs.user.doctor;
using AGENDAMED.Domain.Entities.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Application.Interface.AppServices.user.doctor
{
    public interface IUserDoctorAppService
    {
        Task<DoctorViewModel> CreateDoctor(UserCreateDoctorViewModel userCreateDoctorViewModel);
        Task<DoctorViewModel> EditDoctor(string id,UserEditDoctorViewModel userEditDoctorViewModel);
        Task<DoctorViewModel> GetDoctorById(string doctorID);


        Task<IList<DoctorViewModel>> GetDoctors();

    }
}
