using AGENDAMED.Application.DTOs.appointment;
using AGENDAMED.Domain.Entities.appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Application.Interface.AppServices.appointments
{
    public interface IAppointmentAppService
    {
        Task<List<AppointmentViewModel>> GetAppointmentsUserLogged();

    }
}
