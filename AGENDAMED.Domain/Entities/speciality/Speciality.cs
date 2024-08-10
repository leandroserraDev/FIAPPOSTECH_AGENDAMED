using AGENDAMED.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Domain.Entities.speciality
{
    public class Speciality : EntityID
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
