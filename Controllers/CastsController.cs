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
    public class CastsController : ApiController
    {
        private MatrimonydbEntities db = new MatrimonydbEntities();

        // GET: api/Casts
        public IQueryable<Cast> GetCasts()
        {
            return db.Casts;
        }

        // GET: api/Casts/5
        [ResponseType(typeof(Cast))]
        public async Task<IHttpActionResult> GetCast(int id)
        {
            Cast cast = await db.Casts.FindAsync(id);
            if (cast == null)
            {
                return NotFound();
            }

            return Ok(cast);
        }

        // PUT: api/Casts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCast(int id, Cast cast)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cast.Id)
            {
                return BadRequest();
            }

            db.Entry(cast).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CastExists(id))
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

        // POST: api/Casts
        [ResponseType(typeof(Cast))]
        public async Task<IHttpActionResult> PostCast(Cast cast)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Casts.Add(cast);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cast.Id }, cast);
        }

        // DELETE: api/Casts/5
        [ResponseType(typeof(Cast))]
        public async Task<IHttpActionResult> DeleteCast(int id)
        {
            Cast cast = await db.Casts.FindAsync(id);
            if (cast == null)
            {
                return NotFound();
            }

            db.Casts.Remove(cast);
            await db.SaveChangesAsync();

            return Ok(cast);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CastExists(int id)
        {
            return db.Casts.Count(e => e.Id == id) > 0;
        }
    }
}