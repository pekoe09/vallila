using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vallila.Models.Dtos;
using Vallila.Models.ViewModels;

namespace Vallila.Services
{
    public interface IActivityService
    {
        IEnumerable<ActivityViewModel> GetAll();
        ActivityViewModel GetById(int id);
    }
}
