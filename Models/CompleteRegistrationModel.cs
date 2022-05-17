using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatrimonyAPI.Models
{
    public class CompleteRegistrationModel
    {
        public int UserID { get; set; }
        public virtual PhysicalProfileInfoModel physicalprofileinfo { get; set; }
        public virtual FamilyDetailModel familydetail { get; set; }
        public virtual PartnerPreferanceModel partnerpreferance { get; set; }
        public virtual PermanantAddressModel permanantaddress { get; set; }
        public virtual WorkAddressModel workasddress  { get; set; }
        
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
    }
}