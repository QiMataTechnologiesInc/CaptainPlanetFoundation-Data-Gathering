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
    public class HabitatRestorationsController : ApiController
    {
        private CaptainContext db = new CaptainContext();

        // GET: api/HabitatRestorations
        public IQueryable<HabitatRestoration> GetHabitatRestorations()
        {
            return db.HabitatRestorations.Include(x => x.ProjectBase);
        }

        // GET: api/HabitatRestorations/5
        [ResponseType(typeof(HabitatRestoration))]
        public async Task<IHttpActionResult> GetHabitatRestoration(int id)
        {
            HabitatRestoration habitatRestoration = await db.HabitatRestorations.FindAsync(id);
            if (habitatRestoration == null)
            {
                return NotFound();
            }

            return Ok(habitatRestoration);
        }

        // PUT: api/HabitatRestorations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHabitatRestoration(int id, HabitatRestoration habitatRestoration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != habitatRestoration.HabitatRestorationId)
            {
                return BadRequest();
            }

            db.Entry(habitatRestoration).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HabitatRestorationExists(id))
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

        // POST: api/HabitatRestorations
        [ResponseType(typeof(HabitatRestoration))]
        public async Task<IHttpActionResult> PostHabitatRestoration(HabitatRestoration habitatRestoration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (habitatRestoration.ProjectBase != null)
            {
                habitatRestoration.ProjectBase.DateReported = DateTime.Now;
            }
            db.HabitatRestorations.Add(habitatRestoration);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HabitatRestorationExists(habitatRestoration.HabitatRestorationId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = habitatRestoration.HabitatRestorationId }, habitatRestoration);
        }

        // DELETE: api/HabitatRestorations/5
        [ResponseType(typeof(HabitatRestoration))]
        public async Task<IHttpActionResult> DeleteHabitatRestoration(int id)
        {
            HabitatRestoration habitatRestoration = await db.HabitatRestorations.FindAsync(id);
            if (habitatRestoration == null)
            {
                return NotFound();
            }

            db.HabitatRestorations.Remove(habitatRestoration);
            await db.SaveChangesAsync();

            return Ok(habitatRestoration);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HabitatRestorationExists(int id)
        {
            return db.HabitatRestorations.Count(e => e.HabitatRestorationId == id) > 0;
        }
    }
}