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
    public class RenewableEnergiesController : ApiController
    {
        private CaptainContext db = new CaptainContext();

        // GET: api/RenewableEnergies
        public IQueryable<RenewableEnergy> GetRenewableEnergies()
        {
            return db.RenewableEnergies.Include(x => x.ProjectBase);
        }

        // GET: api/RenewableEnergies/5
        [ResponseType(typeof(RenewableEnergy))]
        public async Task<IHttpActionResult> GetRenewableEnergy(int id)
        {
            RenewableEnergy renewableEnergy = await db.RenewableEnergies.FindAsync(id);
            if (renewableEnergy == null)
            {
                return NotFound();
            }

            return Ok(renewableEnergy);
        }

        // PUT: api/RenewableEnergies/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRenewableEnergy(int id, RenewableEnergy renewableEnergy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != renewableEnergy.RenewableEnergyId)
            {
                return BadRequest();
            }

            db.Entry(renewableEnergy).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RenewableEnergyExists(id))
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

        // POST: api/RenewableEnergies
        [ResponseType(typeof(RenewableEnergy))]
        public async Task<IHttpActionResult> PostRenewableEnergy(RenewableEnergy renewableEnergy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (renewableEnergy.ProjectBase != null)
            {
                renewableEnergy.ProjectBase.DateReported = DateTime.Now;
            }

            db.RenewableEnergies.Add(renewableEnergy);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RenewableEnergyExists(renewableEnergy.RenewableEnergyId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = renewableEnergy.RenewableEnergyId }, renewableEnergy);
        }

        // DELETE: api/RenewableEnergies/5
        [ResponseType(typeof(RenewableEnergy))]
        public async Task<IHttpActionResult> DeleteRenewableEnergy(int id)
        {
            RenewableEnergy renewableEnergy = await db.RenewableEnergies.FindAsync(id);
            if (renewableEnergy == null)
            {
                return NotFound();
            }

            db.RenewableEnergies.Remove(renewableEnergy);
            await db.SaveChangesAsync();

            return Ok(renewableEnergy);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RenewableEnergyExists(int id)
        {
            return db.RenewableEnergies.Count(e => e.RenewableEnergyId == id) > 0;
        }
    }
}