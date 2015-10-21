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
using QiMata.CaptainPlanetFoundation.Dal;

namespace QiMata.CaptainPlanetFoundation.WebApiApp.Api
{
    public class PollinatorGardensController : ApiController
    {
        private CaptainContext db = new CaptainContext();

        // GET: api/PollinatorGardens
        public IQueryable<PollinatorGarden> GetPollinatorGardens()
        {
            return db.PollinatorGardens.Include(x => x.ProjectBase);
        }

        // GET: api/PollinatorGardens/5
        [ResponseType(typeof(PollinatorGarden))]
        public async Task<IHttpActionResult> GetPollinatorGarden(int id)
        {
            PollinatorGarden pollinatorGarden = await db.PollinatorGardens.FindAsync(id);
            if (pollinatorGarden == null)
            {
                return NotFound();
            }

            return Ok(pollinatorGarden);
        }

        // PUT: api/PollinatorGardens/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPollinatorGarden(int id, PollinatorGarden pollinatorGarden)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pollinatorGarden.PollinatorGardenId)
            {
                return BadRequest();
            }

            db.Entry(pollinatorGarden).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PollinatorGardenExists(id))
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

        // POST: api/PollinatorGardens
        [ResponseType(typeof(PollinatorGarden))]
        public async Task<IHttpActionResult> PostPollinatorGarden(PollinatorGarden pollinatorGarden)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PollinatorGardens.Add(pollinatorGarden);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PollinatorGardenExists(pollinatorGarden.PollinatorGardenId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pollinatorGarden.PollinatorGardenId }, pollinatorGarden);
        }

        // DELETE: api/PollinatorGardens/5
        [ResponseType(typeof(PollinatorGarden))]
        public async Task<IHttpActionResult> DeletePollinatorGarden(int id)
        {
            PollinatorGarden pollinatorGarden = await db.PollinatorGardens.FindAsync(id);
            if (pollinatorGarden == null)
            {
                return NotFound();
            }

            db.PollinatorGardens.Remove(pollinatorGarden);
            await db.SaveChangesAsync();

            return Ok(pollinatorGarden);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PollinatorGardenExists(int id)
        {
            return db.PollinatorGardens.Count(e => e.PollinatorGardenId == id) > 0;
        }
    }
}