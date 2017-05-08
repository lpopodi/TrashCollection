using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trash_Collection.Models
{
    public class EmployeeBusinessLogic
    {
        private ApplicationDbContext db;

        public EmployeeBusinessLogic()
        {
            db = new ApplicationDbContext();
        }

        public IQueryable<Service> GetStops(EmployeeSearchModel searchModel)
        {
            var result = db.Services.AsQueryable();
            if (searchModel != null)
            {
                if (searchModel.dayInput != null)
                    result = result.Where(x => x.ServiceDay.Equals(searchModel.dayInput));
                if (!string.IsNullOrEmpty(searchModel.zipInput))
                    result = result.Where(x => x.Pickup.Zip.Equals(searchModel.zipInput));
            }
            return result;
        }
    }
}