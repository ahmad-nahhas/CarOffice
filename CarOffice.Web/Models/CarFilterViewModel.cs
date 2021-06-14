using CarOffice.Shared.Entities;
using CarOffice.Shared.Filters;
using System.Collections.Generic;

namespace CarOffice.Web.Models
{
    public class CarFilterViewModel
    {
        public IEnumerable<Car> Cars { get; set; }
        public CarFilter Filter { get; set; }
    }
}