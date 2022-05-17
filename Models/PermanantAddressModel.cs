using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatrimonyAPI.Models
{
    public class PermanantAddressModel
    {
        public int Id { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public Nullable<int> CountryId { get; set; }

        public Nullable<int> StateId { get; set; }

        public Nullable<int> CityId { get; set; }

        public string AddressType { get; set; }

        public Nullable<int> DistrictId { get; set; }
    }
}