using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vallila.Domain
{
    public class Customer : EntityBase
    {
        public virtual String Name { get; set; }
        public virtual String OfficialId { get; set; }
        public virtual String ContactPerson { get; set; }
        public virtual String EMail { get; set; }
        public virtual String Phone { get; set; }
        public virtual Address ShippingAddress { get; set; }
        public virtual Address BillingAddress { get; set; }
    }
}
