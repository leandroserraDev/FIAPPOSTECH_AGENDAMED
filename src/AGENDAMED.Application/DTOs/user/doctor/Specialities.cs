using AGENDAMED.Domain.Entities.speciality;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Application.DTOs.user.doctor
{
    public class Specialities
    {
        public Specialities(Speciality speciality)
        {
            Name = speciality.Name;
            Description = speciality.Description;
        }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
