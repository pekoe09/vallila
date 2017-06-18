using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vallila.Models.Dtos
{
    public class ActivityDTO
    {
        public int? Id { get; set; }
        public String Name { get; set; }
        public String Abbreviation { get; set; }
        public int? MasterActivityId { get; set; }
    }
}