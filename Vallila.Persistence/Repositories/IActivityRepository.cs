using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vallila.Domain;

namespace Vallila.Persistence.Repositories
{
    public interface IActivityRepository
    {
        IEnumerable<Activity> GetAll();
        Activity GetById(int id);
        Activity Save(Activity activity);
    }
}
