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
    public class ComplexionsController : ApiController
    {
        private MatrimonydbEntities db = new MatrimonydbEntities();

        // GET: api/Complexions
        public IQueryable<Complexion> GetComplexions()
        {
            return db.Complexions;
        }

        // GET: api/Complexions/5
        [ResponseType(typeof(Complexion))]
        public async Task<IHttpActionResult> GetComplexion(int id)
        {
            Complexion complexion = await db.Complexions.FindAsync(id);
            if (complexion == null)
            {
                return NotFound();
            }

            return Ok(complexion);
        }

        // PUT: api/Complexions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutComplexion(int id, Complexion complexion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != complexion.Id)
            {
                return BadRequest();
            }

            db.Entry(complexion).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComplexionExists(id))
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

        // POST: api/Complexions
        [ResponseType(typeof(Complexion))]
        public async Task<IHttpActionResult> PostComplexion(Complexion complexion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Complexions.Add(complexion);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = complexion.Id }, complexion);
        }

        // DELETE: api/Complexions/5
        [ResponseType(typeof(Complexion))]
        public async Task<IHttpActionResult> DeleteComplexion(int id)
        {
            Complexion complexion = await db.Complexions.FindAsync(id);
            if (complexion == null)
            {
                return NotFound();
            }

            db.Complexions.Remove(complexion);
            await db.SaveChangesAsync();

            return Ok(complexion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ComplexionExists(int id)
        {
            return db.Complexions.Count(e => e.Id == id) > 0;
        }
    }
}