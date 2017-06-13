using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vallila.Domain
{
    public class CustomerProjectShare : EntityBase
    {
        public virtual Customer Customer { get; set; }
        public virtual Project Project { get; set; }
        public virtual double Share { get; set; }
    }
}
