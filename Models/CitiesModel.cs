using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatrimonyAPI.Models
{
    public class CitiesModel
    {
        public int Id { get; set; }

        public int DistrictId { get; set; }

        public string CityName { get; set; }
    }
}