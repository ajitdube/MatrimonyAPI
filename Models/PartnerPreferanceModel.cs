using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatrimonyAPI.Models
{
    public class PartnerPreferanceModel
    {
        public int Id { get; set; }

        public Nullable<int> StarId { get; set; }

        public Nullable<int> EducationId { get; set; }

        public Nullable<int> EmployeetypeId { get; set; }

        public Nullable<int> OccupationId { get; set; }

        public Nullable<int> AnnualIncomeId { get; set; }

        public Nullable<int> CountryId { get; set; }

        public Nullable<int> StateId { get; set; }

        public Nullable<int> DistrictId { get; set; }

        public Nullable<int> CityId { get; set; }
    }
}