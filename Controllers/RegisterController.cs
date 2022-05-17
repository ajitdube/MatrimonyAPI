using MatrimonyAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Transactions;
using System.Web.Http;
using System.Web.Http.Description;

namespace MatrimonyAPI.Controllers
{
    public class RegisterController : ApiController
    {
        private MatrimonydbEntities db = new MatrimonydbEntities();

        //  GET: api/Registers
        public Register GetRegister()
        {
            Register rg = new Register();
            return rg;
        }


        [HttpGet]
        [Route("api/Register/GetRegisterDetails/")]
        [ResponseType(typeof(RegisterDetailsModel))]
        public async Task<IHttpActionResult> GetRegisterDetails()
        {
            RegisterDetailsModel rg = new RegisterDetailsModel();
            var command = db.Database.Connection.CreateCommand();
            command.CommandText = "[dbo].[SPR_GetRegisterDetailsResult]";
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                db.Database.Connection.Open();
                var reader = command.ExecuteReader();

                List<ProfileForModel> _listOfProfileFor =
                ((IObjectContextAdapter)db).ObjectContext.Translate<ProfileForModel>
                (reader).ToList();
                reader.NextResult();
                List<GenderModel> _listOfGender =
                    ((IObjectContextAdapter)db).ObjectContext.Translate<GenderModel>
            (reader).ToList();
                reader.NextResult();

                List<LanguageModel> _listOfLanguage =
                ((IObjectContextAdapter)db).ObjectContext.Translate<LanguageModel>
        (reader).ToList();

                reader.NextResult();

                List<ReligionModel> _listOfReligion =
                ((IObjectContextAdapter)db).ObjectContext.Translate<ReligionModel>
        (reader).ToList();

                reader.NextResult();

                List<CountriesModel> _listOfCountries =
                ((IObjectContextAdapter)db).ObjectContext.Translate<CountriesModel>
        (reader).ToList();

                reader.NextResult();

                List<BodyTypeModel> _listOfBodyType =
                ((IObjectContextAdapter)db).ObjectContext.Translate<BodyTypeModel>
        (reader).ToList();

                reader.NextResult();

                List<ComplexionModel> _listOfComplexion =
                ((IObjectContextAdapter)db).ObjectContext.Translate<ComplexionModel>
        (reader).ToList();

                reader.NextResult();

                List<PhysicalStatusModel> _listOfPhysicalStatus =
                ((IObjectContextAdapter)db).ObjectContext.Translate<PhysicalStatusModel>
        (reader).ToList();
                reader.NextResult();

                List<HeightModel> _listOfHeight =
                ((IObjectContextAdapter)db).ObjectContext.Translate<HeightModel>
        (reader).ToList();
                reader.NextResult();
                List<EducationModel> _listOfEducation =
                ((IObjectContextAdapter)db).ObjectContext.Translate<EducationModel>
        (reader).ToList();
                reader.NextResult();

                List<EmploymentTypeModel> _listOfEmploymentType =
                ((IObjectContextAdapter)db).ObjectContext.Translate<EmploymentTypeModel>
        (reader).ToList();

                reader.NextResult();

                List<OccupationModel> _listOfOccupation =
                ((IObjectContextAdapter)db).ObjectContext.Translate<OccupationModel>
        (reader).ToList();

                reader.NextResult();

                List<AnnualincomeModel> _listOfAnnualincome =
                ((IObjectContextAdapter)db).ObjectContext.Translate<AnnualincomeModel>
        (reader).ToList();
                reader.NextResult();

                List<FamilyTypeModel> _listOfFamilyType =
                ((IObjectContextAdapter)db).ObjectContext.Translate<FamilyTypeModel>
        (reader).ToList();

                reader.NextResult();

                List<FamilyStatusModel> _listOfFamilyStatus =
                ((IObjectContextAdapter)db).ObjectContext.Translate<FamilyStatusModel>
        (reader).ToList();

                reader.NextResult();

                List<StarModel> _listOfStar =
                ((IObjectContextAdapter)db).ObjectContext.Translate<StarModel>
        (reader).ToList();

                rg.profilefor = _listOfProfileFor;
                rg.gender = _listOfGender;
                rg.language = _listOfLanguage;
                rg.religion = _listOfReligion;
                rg.country = _listOfCountries;
                rg.bodytype = _listOfBodyType;
                rg.complexion = _listOfComplexion;
                rg.physics_status = _listOfPhysicalStatus;
                rg.height = _listOfHeight;
                rg.highest_education = _listOfEducation;
                rg.employee_type = _listOfEmploymentType;
                rg.occupation = _listOfOccupation;
                rg.annualincome = _listOfAnnualincome;
                rg.familytype = _listOfFamilyType;
                rg.familystatus = _listOfFamilyStatus;
                rg.star = _listOfStar;
                return Ok(rg);
            }
            finally
            {
                db.Database.Connection.Close();
            }
        }




        // POST: api/Register
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> PostRegister(RegisterModel reg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var key = "b14ca5898a4e4133bbce2ea2315a1916";


            var encryptedString = EncryptionDecryption.EncryptString(key, reg.PasswordHash);
            User usermd = new User
            {
                GUID = Guid.NewGuid().ToString(),
                RoleId = reg.RoleId,
                ProfileForId = reg.ProfileForId,
                GenderId = reg.GenderId,
                FullName = reg.FullName,
                DateOfBirth = reg.DateOfBirth,
                Languageid = reg.Languageid,
                ReligionId = reg.ReligionId,
                CastId = reg.CastId,
                CountryId = reg.CountryId,
                StateId = reg.StateId,
                DistrictId = reg.DistrictId,
                CityId = reg.CityId,
                Village = reg.Village,
                PostalCode = reg.PostalCode,
                MobileNumber = reg.MobileNumber,
                EmailId = reg.EmailId,
                PasswordHash = encryptedString,
                SecurityStamp = reg.SecurityStamp,
                EmailConfirmed = reg.EmailConfirmed,
                MobileNumberConfirmed = reg.MobileNumberConfirmed,
                IsActive = reg.IsActive,
                DateCreated = DateTime.Now,
                CreatedBy = reg.CreatedBy,
                DateModified = DateTime.Now,
                ModifiedBy = reg.ModifiedBy,
                Termsandconditions = reg.Termsandconditions

            };
            VendorForClient vendorclient = new VendorForClient
            {
                VendorId = reg.VendorId,
                CreatedBy = reg.CreatedBy,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                ModifiedBy = reg.ModifiedBy

            };

            using (var scope = new TransactionScope(
        TransactionScopeOption.RequiresNew, new TransactionOptions()
        {
            IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted
        }, TransactionScopeAsyncFlowOption.Enabled))
            {
                db.Users.Add(usermd);
                await db.SaveChangesAsync();
                vendorclient.ClientId = usermd.Id;
                reg.Id = usermd.Id;
                if (reg.VendorId != 0)
                {
                    db.VendorForClients.Add(vendorclient);
                    await db.SaveChangesAsync();
                }

                scope.Complete();
            }


            // await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = usermd.Id }, reg);
        }

        // Get: api/Register
        [HttpPost]
        [Route("api/Register/CompleteRegistration")]         
        public async Task<IHttpActionResult> CompleteRegister(CompleteRegistrationModel reg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (reg  == null)
            {
                return BadRequest();
            }
            PhysicalProfileInfo Ppinfo = new PhysicalProfileInfo
            {
                BodyTypeId = reg.physicalprofileinfo.BodyTypeId,
                ComplexionId = reg.physicalprofileinfo.ComplexionId,
                PhysicalStatusId = reg.physicalprofileinfo.PhysicalStatusId,
                HeightId = reg.physicalprofileinfo.HeightId,
                Weight = reg.physicalprofileinfo.Weight,
                EducationId = reg.physicalprofileinfo.EducationId,
                EmploymentTypeId = reg.physicalprofileinfo.EmploymentTypeId,
                OccupationId = reg.physicalprofileinfo.OccupationId,
                AnnualIncomeId = reg.physicalprofileinfo.AnnualIncomeId,
                UserId =reg.UserID,
                DateCreated= DateTime.Now,
                CreatedBy = reg.CreatedBy,
                ModofiedBy = reg.ModifiedBy,
                DateModified = DateTime.Now
            };

            FamilyDetail Fmdtl = new FamilyDetail
            {

                FamilytypeId = reg.familydetail.FamilytypeId,
                FamilystatusId = reg.familydetail.FamilystatusId,
                FathersSurname = reg.familydetail.FathersSurname,
                FathersName = reg.familydetail.FathersName,
                FathersOccupation = reg.familydetail.FathersOccupation,
                MothersSurname = reg.familydetail.MothersSurname,
                MothersName = reg.familydetail.MothersName,
                MothersOccupation = reg.familydetail.MothersOccupation,
                NoOfSisters = reg.familydetail.NoOfSisters,
                NoOfBrothers = reg.familydetail.NoOfBrothers,
                UserId = reg.UserID,
                DateCreated = DateTime.Now,
                CreatedBy = reg.CreatedBy,
                ModifiedBy = reg.ModifiedBy,
                DateModified = DateTime.Now
            };

            PartnerPreferance Prtpre = new PartnerPreferance
            {
                StarId = reg.partnerpreferance.StarId,
                EducationId = reg.partnerpreferance.EducationId,
                EmployeetypeId = reg.partnerpreferance.EmployeetypeId,
                OccupationId = reg.partnerpreferance.OccupationId,
                AnnualIncomeId = reg.partnerpreferance.AnnualIncomeId,
                CountryId = reg.partnerpreferance.CountryId,
                StateId = reg.partnerpreferance.StateId,
                DistrictId = reg.partnerpreferance.DistrictId,
                CityId = reg.partnerpreferance.CityId,
                UserId = reg.UserID,
                DateCreated = DateTime.Now,
                CreatedBy = reg.CreatedBy,
                ModifiedBy = reg.ModifiedBy,
                DateModified = DateTime.Now
            };
            PermanantAddress Peradd = new PermanantAddress
            {
                Address1 = reg.permanantaddress.Address1,
                Address2 = reg.permanantaddress.Address2,
                CountryId = reg.permanantaddress.CountryId,
                StateId = reg.permanantaddress.StateId,
                CityId = reg.permanantaddress.CityId,
                AddressType = reg.permanantaddress.AddressType,
                DistrictId = reg.permanantaddress.DistrictId,
                UserId = reg.UserID,
                DateCreated = DateTime.Now,
                CreatedBy = reg.CreatedBy,
                ModifiedBy = reg.ModifiedBy,
                DateModified = DateTime.Now

            };

            using (var scope = new TransactionScope(
     TransactionScopeOption.RequiresNew, new TransactionOptions()
     {
         IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted
     }, TransactionScopeAsyncFlowOption.Enabled))
            {
                if (db.PhysicalProfileInfoes.Any(e => e.UserId == reg.UserID))
                {
                    db.Entry(Ppinfo).State = EntityState.Modified;
                }
                else
                {
                    db.PhysicalProfileInfoes.Add(Ppinfo);
                }
                if (db.FamilyDetails.Any(e => e.UserId == reg.UserID))
                {
                    db.Entry(Fmdtl).State = EntityState.Modified;
                }
                else
                {
                    db.FamilyDetails.Add(Fmdtl);
                }
                if (db.PartnerPreferances.Any(e => e.UserId == reg.UserID))
                {
                    db.Entry(Prtpre).State = EntityState.Modified;
                }
                else
                {
                    db.PartnerPreferances.Add(Prtpre);
                }

                if (db.PermanantAddresses.Any(e => e.UserId == reg.UserID))
                {
                    db.Entry(Peradd).State = EntityState.Modified;
                }
                else
                {
                    db.PermanantAddresses.Add(Peradd);
                }
                await db.SaveChangesAsync();
                scope.Complete();

            }
            
            return Ok(reg);  
        }
    }
}
