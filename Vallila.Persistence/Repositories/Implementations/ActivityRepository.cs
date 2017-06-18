using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vallila.Domain;

namespace Vallila.Persistence.Repositories.Implementations
{
    public class ActivityRepository : IActivityRepository
    {
        public IEnumerable<Activity> GetAll()
        {
            throw new NotImplementedException();
        }

        public Activity GetById(int id)
        {
            return null;
        }

        public Activity Save(Activity activity)
        {
            throw new NotImplementedException();
        }
    }
}
