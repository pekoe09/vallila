using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vallila.Domain
{
    public class Address : EntityBase
    {
        public virtual String Street1 { get; set; }
        public virtual String Street2 { get; set; }
        public virtual String Zip { get; set; }
        public virtual String City { get; set; }
        public virtual String Country { get; set; }
    }
}
