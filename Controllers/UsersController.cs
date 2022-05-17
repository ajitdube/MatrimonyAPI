﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MatrimonyAPI.Models;

namespace MatrimonyAPI.Controllers
{
    public class UsersController : ApiController
    {
        private MatrimonydbEntities db = new MatrimonydbEntities();

        // GET: api/Users
        //public IQueryable<User> GetUsers()
        //{
        //    return db.Users;
        //}
        // GET: api/Users/GetUserDetails/5       
        [HttpGet]
       // [Route("api/Users/")]
        [ResponseType(typeof(UserDetailsModel))]
        public async Task<IHttpActionResult> GetUser(int id)
        {

            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            PhysicalProfileInfo Phyinfo = await db.PhysicalProfileInfoes.Where(e => e.UserId == id).FirstOrDefaultAsync();
            FamilyDetail FamlDtl = await db.FamilyDetails.Where(x => x.UserId == id).FirstOrDefaultAsync();
            PartnerPreferance PartPref = await db.PartnerPreferances.Where(x => x.UserId == id).FirstOrDefaultAsync();
            WorkAddress WrkAddr = await db.WorkAddresses.Where(x => x.UserId == id).FirstOrDefaultAsync();

            UserDetailsModel UserDtl = new UserDetailsModel
            {
                GUID = user.GUID,
                RoleId = user.RoleId,
                ProfileForId = user.ProfileForId,
                GenderId = user.GenderId,
                FullName = user.FullName,
                DateOfBirth = user.DateOfBirth,
                Languageid = user.Languageid,
                ReligionId = user.ReligionId,
                CastId = user.CastId,
                CountryId = user.CountryId,
                StateId = user.StateId,
                DistrictId = user.DistrictId,
                CityId = user.CityId,
                Village = user.Village,
                PostalCode = user.PostalCode,
                MobileNumber = user.MobileNumber,
                EmailId = user.EmailId,
                EmailConfirmed = user.EmailConfirmed,
                MobileNumberConfirmed = user.MobileNumberConfirmed,
                IsActive = user.IsActive,
                Termsandconditions = user.Termsandconditions

            };
            if (Phyinfo != null)
            {
                PhysicalProfileInfoModel Phyinfobj = new PhysicalProfileInfoModel
                {
                    BodyTypeId = Phyinfo.BodyTypeId,
                    ComplexionId = Phyinfo.ComplexionId,
                    PhysicalStatusId = Phyinfo.PhysicalStatusId,
                    HeightId = Phyinfo.HeightId,
                    Weight = Phyinfo.Weight,
                    EducationId = Phyinfo.EducationId,
                    EmploymentTypeId = Phyinfo.EmploymentTypeId,
                    OccupationId = Phyinfo.OccupationId,
                    AnnualIncomeId = Phyinfo.AnnualIncomeId
                };
                UserDtl.physicalprofileinfo = Phyinfobj;
            }


            if (FamlDtl != null)
            {
                FamilyDetailModel Fmlyobj = new FamilyDetailModel
                {
                    FamilytypeId = FamlDtl.FamilytypeId,
                    FamilystatusId = FamlDtl.FamilystatusId,
                    FathersSurname = FamlDtl.FathersSurname,
                    FathersName = FamlDtl.FathersName,
                    FathersOccupation = FamlDtl.FathersOccupation,
                    MothersSurname = FamlDtl.MothersSurname,
                    MothersName = FamlDtl.MothersName,
                    MothersOccupation = FamlDtl.MothersOccupation,
                    NoOfSisters = FamlDtl.NoOfSisters,
                    NoOfBrothers = FamlDtl.NoOfBrothers
                };
                UserDtl.familydetail = Fmlyobj;
            }
            if (PartPref != null)
            {
                PartnerPreferanceModel Partpre= new PartnerPreferanceModel
                {
                    StarId = PartPref.StarId,
                    EducationId = PartPref.EducationId,
                    EmployeetypeId = PartPref.EmployeetypeId,
                    OccupationId = PartPref.OccupationId,
                    AnnualIncomeId = PartPref.AnnualIncomeId,
                    CountryId = PartPref.CountryId,
                    StateId = PartPref.StateId,
                    DistrictId = PartPref.DistrictId,
                    CityId = PartPref.CityId
            };
            UserDtl.partnerpreferance = Partpre;


            }
            if(WrkAddr!=null)
            {
                WorkAddressModel wrkaddrObj = new WorkAddressModel
                {
                    Address1 = WrkAddr.Address1,
                    Address2 = WrkAddr.Address2,
                    CountryId = WrkAddr.CountryId,
                    StateId = WrkAddr.StateId,
                    DistrictId = WrkAddr.DistrictId,
                    CityId = WrkAddr.CityId,
                    AddressType = WrkAddr.AddressType                    
                };
                UserDtl.workasddress = wrkaddrObj;
            }


            return Ok(UserDtl);
        }
        //// GET: api/Users/5
        //[ResponseType(typeof(User))]
        //public async Task<IHttpActionResult> GetUser(int id)
        //{
        //    User user = await db.Users.FindAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(user);
        //}

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Users
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(user);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> DeleteUser(int id)
        {
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            await db.SaveChangesAsync();

            return Ok(user);
        }

     

        // UserExists: api/UserExists/5
        [ResponseType(typeof(User))]
        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
        // ValidateEmail: api/ValidateEmail/a@a.com
        //[HttpGet]
        //[Route("api/Users/GetEmailValidate/")]
        //private bool GetEmailValidate(string emailId)
        //{
        //    return db.Users.Count(e => e.EmailId == emailId) > 0;
        //}
        //// MobileExists: api/ValidateMobile/999999999
        //[HttpGet]
        //private bool ValidateMobile(string mobilenm)
        //{
        //    return db.Users.Count(e => e.MobileNumber == mobilenm) > 0;
        //}
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}