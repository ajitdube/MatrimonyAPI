using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatrimonyAPI.Models
{
    public class UserDetailsModel
    {
        public int Id { get; set; }

        public Nullable<int> RoleId { get; set; }

        public Nullable<int> ProfileForId { get; set; }

        public Nullable<int> GenderId { get; set; }

        public string FullName { get; set; }

        public Nullable<System.DateTime> DateOfBirth { get; set; }

        public Nullable<int> Languageid { get; set; }

        public Nullable<int> ReligionId { get; set; }

        public Nullable<int> CastId { get; set; }

        public Nullable<int> CountryId { get; set; }

        public Nullable<int> StateId { get; set; }

        public Nullable<int> DistrictId { get; set; }

        public Nullable<int> CityId { get; set; }

        public string Village { get; set; }

        public string PostalCode { get; set; }

        public string MobileNumber { get; set; }

        public string EmailId { get; set; }       

        public Nullable<bool> EmailConfirmed { get; set; }

        public Nullable<bool> MobileNumberConfirmed { get; set; }

        public Nullable<bool> IsActive { get; set; }     

        public string Termsandconditions { get; set; }

        public string GUID { get; set; }

        public virtual PhysicalProfileInfoModel physicalprofileinfo { get; set; }
        public virtual FamilyDetailModel familydetail { get; set; }
        public virtual PartnerPreferanceModel partnerpreferance { get; set; }
        public virtual PermanantAddressModel permanantaddress { get; set; }

        public virtual WorkAddressModel workasddress { get; set; }
    }
}