using System;
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
    public class EmploymentTypesController : ApiController
    {
        private MatrimonydbEntities db = new MatrimonydbEntities();

        // GET: api/EmploymentTypes
        public IQueryable<EmploymentType> GetEmploymentTypes()
        {
            return db.EmploymentTypes;
        }

        // GET: api/EmploymentTypes/5
        [ResponseType(typeof(EmploymentType))]
        public async Task<IHttpActionResult> GetEmploymentType(int id)
        {
            EmploymentType employmentType = await db.EmploymentTypes.FindAsync(id);
            if (employmentType == null)
            {
                return NotFound();
            }

            return Ok(employmentType);
        }

        // PUT: api/EmploymentTypes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEmploymentType(int id, EmploymentType employmentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employmentType.Id)
            {
                return BadRequest();
            }

            db.Entry(employmentType).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmploymentTypeExists(id))
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

        // POST: api/EmploymentTypes
        [ResponseType(typeof(EmploymentType))]
        public async Task<IHttpActionResult> PostEmploymentType(EmploymentType employmentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmploymentTypes.Add(employmentType);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = employmentType.Id }, employmentType);
        }

        // DELETE: api/EmploymentTypes/5
        [ResponseType(typeof(EmploymentType))]
        public async Task<IHttpActionResult> DeleteEmploymentType(int id)
        {
            EmploymentType employmentType = await db.EmploymentTypes.FindAsync(id);
            if (employmentType == null)
            {
                return NotFound();
            }

            db.EmploymentTypes.Remove(employmentType);
            await db.SaveChangesAsync();

            return Ok(employmentType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmploymentTypeExists(int id)
        {
            return db.EmploymentTypes.Count(e => e.Id == id) > 0;
        }
    }
}