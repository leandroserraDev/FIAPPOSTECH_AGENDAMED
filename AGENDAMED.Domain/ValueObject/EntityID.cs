using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Domain.ValueObject
{
    public abstract class EntityID
    {
        protected EntityID(bool deleted)
        {
            Deleted = deleted;
        }
        protected EntityID()
        {
            
        }

        public long ID { get; private set; }
        public DateTime DtCreated{ get; private set; }
        public DateTime DtModified { get; private set; }
        public bool Deleted { get; private set; }


    }
}
