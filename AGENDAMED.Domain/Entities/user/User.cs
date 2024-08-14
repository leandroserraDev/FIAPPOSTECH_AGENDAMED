using AGENDAMED.Domain.Entities.user.doctor;
using AGENDAMED.Domain.Entities.user.patient;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Domain.Entities.user
{
    public class User :IdentityUser
    {

        public User()
        {

        }

        public string Name  {  get; set; }
        public string LastName {  get; set; }

        public virtual Doctor? Doctor { get; set; }
        public virtual Patient?  Patient{ get; set; }

    }
}
