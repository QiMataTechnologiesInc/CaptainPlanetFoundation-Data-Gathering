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
    public class WaterQualityMonitoringsController : ApiController
    {
        private CaptainContext db = new CaptainContext();

        // GET: api/WaterQualityMonitorings
        public IQueryable<WaterQualityMonitoring> GetWaterQualityMonitorings()
        {
            return db.WaterQualityMonitorings.Include(x => x.ProjectBase);
        }

        // GET: api/WaterQualityMonitorings/5
        [ResponseType(typeof(WaterQualityMonitoring))]
        public async Task<IHttpActionResult> GetWaterQualityMonitoring(int id)
        {
            WaterQualityMonitoring waterQualityMonitoring = await db.WaterQualityMonitorings.FindAsync(id);
            if (waterQualityMonitoring == null)
            {
                return NotFound();
            }

            return Ok(waterQualityMonitoring);
        }

        // PUT: api/WaterQualityMonitorings/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutWaterQualityMonitoring(int id, WaterQualityMonitoring waterQualityMonitoring)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != waterQualityMonitoring.WaterQualityMonitoringId)
            {
                return BadRequest();
            }

            db.Entry(waterQualityMonitoring).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WaterQualityMonitoringExists(id))
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

        // POST: api/WaterQualityMonitorings
        [ResponseType(typeof(WaterQualityMonitoring))]
        public async Task<IHttpActionResult> PostWaterQualityMonitoring(WaterQualityMonitoring waterQualityMonitoring)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WaterQualityMonitorings.Add(waterQualityMonitoring);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WaterQualityMonitoringExists(waterQualityMonitoring.WaterQualityMonitoringId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = waterQualityMonitoring.WaterQualityMonitoringId }, waterQualityMonitoring);
        }

        // DELETE: api/WaterQualityMonitorings/5
        [ResponseType(typeof(WaterQualityMonitoring))]
        public async Task<IHttpActionResult> DeleteWaterQualityMonitoring(int id)
        {
            WaterQualityMonitoring waterQualityMonitoring = await db.WaterQualityMonitorings.FindAsync(id);
            if (waterQualityMonitoring == null)
            {
                return NotFound();
            }

            db.WaterQualityMonitorings.Remove(waterQualityMonitoring);
            await db.SaveChangesAsync();

            return Ok(waterQualityMonitoring);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WaterQualityMonitoringExists(int id)
        {
            return db.WaterQualityMonitorings.Count(e => e.WaterQualityMonitoringId == id) > 0;
        }
    }
}