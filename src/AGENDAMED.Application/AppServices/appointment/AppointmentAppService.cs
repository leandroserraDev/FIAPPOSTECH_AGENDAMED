using AGENDAMED.Application.DTOs.appointment;
using AGENDAMED.Application.Interface.AppServices.appointments;
using AGENDAMED.Domain.Interface.Services.appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Application.AppServices.appointment
{
    public class AppointmentAppService : IAppointmentAppService
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentAppService(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public async Task<List<AppointmentViewModel>> GetAppointmentsUserLogged()
        {
            var result = await _appointmentService.GetAppointmentsUserLoggedPatient();

            if (result == null) return null;

            var list = new List<AppointmentViewModel>();
            foreach (var item in result) 
            {
                list.Add(new(item));
            }

            return await Task.FromResult(list);
        }
    }
}
