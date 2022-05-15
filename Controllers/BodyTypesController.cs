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
    public class BodyTypesController : ApiController
    {
        private MatrimonydbEntities db = new MatrimonydbEntities();

        // GET: api/BodyTypes
        public IQueryable<BodyType> GetBodyTypes()
        {
            return db.BodyTypes;
        }

        // GET: api/BodyTypes/5
        [ResponseType(typeof(BodyType))]
        public async Task<IHttpActionResult> GetBodyType(int id)
        {
            BodyType bodyType = await db.BodyTypes.FindAsync(id);
            if (bodyType == null)
            {
                return NotFound();
            }

            return Ok(bodyType);
        }

        // PUT: api/BodyTypes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBodyType(int id, BodyType bodyType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bodyType.Id)
            {
                return BadRequest();
            }

            db.Entry(bodyType).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BodyTypeExists(id))
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

        // POST: api/BodyTypes
        [ResponseType(typeof(BodyType))]
        public async Task<IHttpActionResult> PostBodyType(BodyType bodyType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BodyTypes.Add(bodyType);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = bodyType.Id }, bodyType);
        }

        // DELETE: api/BodyTypes/5
        [ResponseType(typeof(BodyType))]
        public async Task<IHttpActionResult> DeleteBodyType(int id)
        {
            BodyType bodyType = await db.BodyTypes.FindAsync(id);
            if (bodyType == null)
            {
                return NotFound();
            }

            db.BodyTypes.Remove(bodyType);
            await db.SaveChangesAsync();

            return Ok(bodyType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BodyTypeExists(int id)
        {
            return db.BodyTypes.Count(e => e.Id == id) > 0;
        }
    }
}