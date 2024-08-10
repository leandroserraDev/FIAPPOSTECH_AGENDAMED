using AGENDAMED.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Domain.Entities.address
{
    public class Address : EntityID
    {
        public string CEP { get; private set; }
        public string Street { get; private set; }
        public int Number { get; private set; }
        public string UF { get; set; }
        public string Country { get; private set; }
        protected Address()
        {
            
        }

        public Address(string cEP, 
                       string street, 
                       int number, 
                       string uF, string country)
        {
            CEP = cEP;
            Street = street;
            Number = number;
            UF = uF;
            Country = country;
        }
    }
}
