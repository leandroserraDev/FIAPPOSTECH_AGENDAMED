using AGENDAMED.Domain.Enums;
using AGENDAMED.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Domain.Entities.user
{
    public class User : EntityID
    {
        public User(string name,
                    string lastName,
                    DateTime birthDate,
                    ETypePerson typePerson,
                    string document,
                    string addressImagePhoto)
        {
            Name = name;
            LastName = lastName;
            BirthDate = birthDate;
            TypePerson = typePerson;
            Document = document;
            AddressImagePhoto = addressImagePhoto;
        }

        protected User()
        {
            
        }

        public string Name { get; private set; }
        public string LastName{ get; private set; }
        public DateTime BirthDate { get; private set; }
        public ETypePerson TypePerson { get; private set; }
        public string Document { get; private set; }
        public string AddressImagePhoto { get; private set; }


    }
}
