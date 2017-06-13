using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vallila.Domain
{
    public class LoggedTime : EntityBase
    {
        public virtual User User { get; set; }
        public virtual Activity Activity { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Project Project { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime EndTime { get; set; }
        public virtual String Description { get; set; }
    }
}
