using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vallila.Models.Dtos;

namespace Vallila.Models.ViewModels
{
    public class ActivityViewModel
    {
        public int? Id { get; set; }
        public String Name { get; set; }
        public String Abbreviation { get; set; }
        public ActivityDTO MasterActivityId { get; set; }
        public List<ActivityDTO> Activities { get; set; }
    }
}