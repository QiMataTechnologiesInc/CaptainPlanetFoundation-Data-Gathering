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
    public class WasteDiversionsController : ApiController
    {
        private CaptainContext db = new CaptainContext();

        // GET: api/WasteDiversions
        public IQueryable<WasteDiversion> GetWasteDiversions()
        {
            return db.WasteDiversions.Include(x => x.ProjectBase);
        }

        // GET: api/WasteDiversions/5
        [ResponseType(typeof(WasteDiversion))]
        public async Task<IHttpActionResult> GetWasteDiversion(int id)
        {
            WasteDiversion wasteDiversion = await db.WasteDiversions.FindAsync(id);
            if (wasteDiversion == null)
            {
                return NotFound();
            }

            return Ok(wasteDiversion);
        }

        // PUT: api/WasteDiversions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutWasteDiversion(int id, WasteDiversion wasteDiversion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != wasteDiversion.WasteDiversionId)
            {
                return BadRequest();
            }

            db.Entry(wasteDiversion).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WasteDiversionExists(id))
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

        // POST: api/WasteDiversions
        [ResponseType(typeof(WasteDiversion))]
        public async Task<IHttpActionResult> PostWasteDiversion(WasteDiversion wasteDiversion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WasteDiversions.Add(wasteDiversion);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WasteDiversionExists(wasteDiversion.WasteDiversionId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = wasteDiversion.WasteDiversionId }, wasteDiversion);
        }

        // DELETE: api/WasteDiversions/5
        [ResponseType(typeof(WasteDiversion))]
        public async Task<IHttpActionResult> DeleteWasteDiversion(int id)
        {
            WasteDiversion wasteDiversion = await db.WasteDiversions.FindAsync(id);
            if (wasteDiversion == null)
            {
                return NotFound();
            }

            db.WasteDiversions.Remove(wasteDiversion);
            await db.SaveChangesAsync();

            return Ok(wasteDiversion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WasteDiversionExists(int id)
        {
            return db.WasteDiversions.Count(e => e.WasteDiversionId == id) > 0;
        }
    }
}