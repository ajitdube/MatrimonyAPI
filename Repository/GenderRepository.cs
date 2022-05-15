using MatrimonyAPI.Interface;
using MatrimonyAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MatrimonyAPI.Repository
{
    public class GenderRepository : GenderInterface
    {
        private readonly MatrimonydbEntities db = new MatrimonydbEntities();
        public async Task Add(Gender genders)
        {
            genders.Id = Convert.ToInt32(Guid.NewGuid().ToString());
            db.Genders.Add(genders);
            try
            {
                await db.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task Delete(string Id)
        {
            try
            {
                Gender gender = await db.Genders.FindAsync(Id);
                db.Genders.Remove(gender);
                await db.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Gender> GetGender(string id)
        {
            try
            {
                Gender gender = await db.Genders.FindAsync(id);
                if (gender == null)
                {
                    return null;
                }
                return gender;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Gender>> GetGenders()
        {
            try
            {
                var gender = await db.Genders.ToListAsync();
                return gender.AsQueryable();
            }
            catch
            {
                throw;
            }
        }

        public async Task Update(Gender gender)
        {
            try
            {
                db.Entry(gender).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        private bool GenderExists(int id)
        {
            return db.Genders.Count(e => e.Id == id) > 0;
        }
    }
}