using MatrimonyAPI.Models;
using System;
using System.Collections.Generic;
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

        // GET: api/Registers
        //public Register GetRegister()
        //{
        //    Register rg = new Register();
        //    return rg;
        //}

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
                RoleId = 3,
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
                Termsandconditions= reg.Termsandconditions
                
            };
            VendorForClient vendorclient = new VendorForClient
            {
                VendorId = reg.VendorId,
                CreatedBy= reg.CreatedBy,
                DateCreated= DateTime.Now,
                DateModified = DateTime.Now,
                ModifiedBy = reg.ModifiedBy

            };

            using (var scope = new TransactionScope(
        TransactionScopeOption.RequiresNew, new TransactionOptions()
        {
            IsolationLevel = IsolationLevel.ReadCommitted
        }, TransactionScopeAsyncFlowOption.Enabled))
            {
                db.Users.Add(usermd);
                await db.SaveChangesAsync();
                vendorclient.ClientId = usermd.Id;
                reg.Id = usermd.Id;  
                if(reg.VendorId !=0)
                {
                    db.VendorForClients.Add(vendorclient);
                    await db.SaveChangesAsync();
                }
            
                scope.Complete();
            }

            
           // await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = usermd.Id }, reg);
        }

        // GET: api/Register/5
        //[ResponseType(typeof(User))]
        //public async Task<IHttpActionResult> GetRegister(int id)
        //{
        //    User reg = await db.Users.FindAsync(id);
        //    if (reg == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(reg);
        //}
        //[HttpGet]
        //[Route("api/Register/GetEmailValidate/")]
        //private bool GetEmailValidate(string emailId)
        //{
        //    return db.Users.Count(e => e.EmailId == emailId) > 0;
        //}
    }
}
