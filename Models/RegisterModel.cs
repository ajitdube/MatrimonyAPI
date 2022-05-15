using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatrimonyAPI.Models
{
    public class RegisterModel
    {        
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int ProfileForId { get; set; }
        public int GenderId { get; set; }
        public  string FullName { get; set; }
        public  DateTime DateOfBirth { get; set; }
        public int  Languageid { get; set; }
        public int  ReligionId { get; set; }
        public int  CastId { get; set; }
        public int  CountryId { get; set; }
        public int  StateId { get; set; }
        public int  DistrictId { get; set; }
        public int CityId { get; set; }
        public  string Village { get; set; }
        public string  PostalCode { get; set; }
        public string  MobileNumber { get; set; }
        public string EmailId { get; set; }
        public string  PasswordHash { get; set; }
        public string  SecurityStamp { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool MobileNumberConfirmed { get; set; }
        public bool  IsActive { get; set; }
        public DateTime  DateCreated { get; set; }
        public int  CreatedBy { get; set; }
        public DateTime DateModified { get; set; }
        public int ModifiedBy { get; set; }
        public int VendorId { get; set; }
        public string Termsandconditions { get; set; }

    }
}