using AGENDAMED.Application.AppServices.serviceBase;
using AGENDAMED.Application.DTOs.user.doctor;
using AGENDAMED.Application.Interface.AppServices.user.doctor;
using AGENDAMED.Domain.Entities.user;
using AGENDAMED.Domain.Interface.Services;
using AGENDAMED.Domain.Interface.Services.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Application.AppServices.user.doctor
{
    public class UserDoctorAppService : IUserDoctorAppService
    {
        private readonly IUserService _userService;

        public UserDoctorAppService(IUserService userService)
        {
            _userService = userService;
        }

        public async  Task<DoctorViewModel> CreateDoctor(UserCreateDoctorViewModel userCreateDoctorViewModel)
        {
            var doctorToDomain = userCreateDoctorViewModel.ToDomain();

            var result = await _userService.CreateDoctor(doctorToDomain);

            if(result == null) { return null; }
            return await Task.FromResult(new DoctorViewModel(result));
        }

        public async Task<DoctorViewModel> EditDoctor(string id, UserEditDoctorViewModel userEditDoctorViewModel)
        {
            var result = await _userService.UpdateDoctor(id,userEditDoctorViewModel.ToDomain());

            if (result == null) { return null; }
            return await Task.FromResult(new DoctorViewModel(result));


        }

        public async Task<IList<DoctorViewModel>> GetDoctors()
        {
            var result = await _userService.GetUsersDoctor();

            if(result == null)
            {
                return null;
            }

            var listItens = new List<DoctorViewModel>();
            result.ForEach(obj =>
            {
                listItens.Add(new DoctorViewModel(obj));
            });

            return await Task.FromResult(listItens);
        }
    }
}
