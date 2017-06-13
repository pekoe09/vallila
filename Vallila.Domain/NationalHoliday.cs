using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vallila.Domain
{
    public class NationalHoliday : EntityBase
    {
        public virtual String Name { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual String Description { get; set; }
    }
}
