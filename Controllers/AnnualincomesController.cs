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
    public class AnnualincomesController : ApiController
    {
        private MatrimonydbEntities db = new MatrimonydbEntities();

        // GET: api/Annualincomes
        public IQueryable<Annualincome> GetAnnualincomes()
        {
            return db.Annualincomes;
        }

        // GET: api/Annualincomes/5
        [ResponseType(typeof(Annualincome))]
        public async Task<IHttpActionResult> GetAnnualincome(int id)
        {
            Annualincome annualincome = await db.Annualincomes.FindAsync(id);
            if (annualincome == null)
            {
                return NotFound();
            }

            return Ok(annualincome);
        }

        // PUT: api/Annualincomes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAnnualincome(int id, Annualincome annualincome)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != annualincome.Id)
            {
                return BadRequest();
            }

            db.Entry(annualincome).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnnualincomeExists(id))
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

        // POST: api/Annualincomes
        [ResponseType(typeof(Annualincome))]
        public async Task<IHttpActionResult> PostAnnualincome(Annualincome annualincome)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Annualincomes.Add(annualincome);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = annualincome.Id }, annualincome);
        }

        // DELETE: api/Annualincomes/5
        [ResponseType(typeof(Annualincome))]
        public async Task<IHttpActionResult> DeleteAnnualincome(int id)
        {
            Annualincome annualincome = await db.Annualincomes.FindAsync(id);
            if (annualincome == null)
            {
                return NotFound();
            }

            db.Annualincomes.Remove(annualincome);
            await db.SaveChangesAsync();

            return Ok(annualincome);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnnualincomeExists(int id)
        {
            return db.Annualincomes.Count(e => e.Id == id) > 0;
        }
    }
}