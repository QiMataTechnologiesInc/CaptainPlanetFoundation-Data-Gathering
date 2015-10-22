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
    public class ReforestationsController : ApiController
    {
        private CaptainContext db = new CaptainContext();

        // GET: api/Reforestations
        public IQueryable<Reforestation> GetReforestations()
        {
            return db.Reforestations.Include(x => x.ProjectBase);
        }

        // GET: api/Reforestations/5
        [ResponseType(typeof(Reforestation))]
        public async Task<IHttpActionResult> GetReforestation(int id)
        {
            Reforestation reforestation = await db.Reforestations.FindAsync(id);
            if (reforestation == null)
            {
                return NotFound();
            }

            return Ok(reforestation);
        }

        // PUT: api/Reforestations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutReforestation(int id, Reforestation reforestation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reforestation.ReforestationId)
            {
                return BadRequest();
            }

            db.Entry(reforestation).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReforestationExists(id))
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

        // POST: api/Reforestations
        [ResponseType(typeof(Reforestation))]
        public async Task<IHttpActionResult> PostReforestation(Reforestation reforestation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (reforestation.ProjectBase != null)
            {
                reforestation.ProjectBase.DateReported = DateTime.Now;
            }
            db.Reforestations.Add(reforestation);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ReforestationExists(reforestation.ReforestationId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = reforestation.ReforestationId }, reforestation);
        }

        // DELETE: api/Reforestations/5
        [ResponseType(typeof(Reforestation))]
        public async Task<IHttpActionResult> DeleteReforestation(int id)
        {
            Reforestation reforestation = await db.Reforestations.FindAsync(id);
            if (reforestation == null)
            {
                return NotFound();
            }

            db.Reforestations.Remove(reforestation);
            await db.SaveChangesAsync();

            return Ok(reforestation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReforestationExists(int id)
        {
            return db.Reforestations.Count(e => e.ReforestationId == id) > 0;
        }
    }
}