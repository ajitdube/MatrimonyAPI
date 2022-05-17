using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatrimonyAPI.Models
{
    public class PhysicalProfileInfoModel
    {
        public int Id { get; set; }      

        public Nullable<int> BodyTypeId { get; set; }

        public Nullable<int> ComplexionId { get; set; }

        public Nullable<int> PhysicalStatusId { get; set; }

        public Nullable<int> HeightId { get; set; }

        public Nullable<decimal> Weight { get; set; }

        public Nullable<int> EducationId { get; set; }

        public Nullable<int> EmploymentTypeId { get; set; }

        public Nullable<int> OccupationId { get; set; }

        public Nullable<int> AnnualIncomeId { get; set; }
    }
}