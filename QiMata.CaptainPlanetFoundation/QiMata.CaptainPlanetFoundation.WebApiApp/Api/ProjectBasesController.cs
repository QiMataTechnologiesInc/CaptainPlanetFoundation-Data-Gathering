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
    public class ProjectBasesController : ApiController
    {
        private CaptainContext db = new CaptainContext();

        // GET: api/ProjectBases
        public IQueryable<ProjectBase> GetProjectBases()
        {
            return db.ProjectBases
                .Include(x => x.AquaponicProject)
                .Include(x => x.EditableGarden)
                .Include(x => x.HabitatRestoration)
                .Include(x => x.PollinatorGarden)
                .Include(x => x.Reforestation)
                .Include(x => x.RenewableEnergy)
                .Include(x => x.WasteDiversion)
                .Include(x => x.WaterQualityMonitoring)
                .OrderBy(x => x.DateReported);
        }

        // GET: api/ProjectBases/5
        [ResponseType(typeof(ProjectBase))]
        public async Task<IHttpActionResult> GetProjectBase(int id)
        {
            ProjectBase projectBase = await db.ProjectBases.FindAsync(id);
            if (projectBase == null)
            {
                return NotFound();
            }

            return Ok(projectBase);
        }

        // PUT: api/ProjectBases/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProjectBase(int id, ProjectBase projectBase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != projectBase.ProjectBaseId)
            {
                return BadRequest();
            }

            db.Entry(projectBase).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectBaseExists(id))
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

        // POST: api/ProjectBases
        [ResponseType(typeof(ProjectBase))]
        public async Task<IHttpActionResult> PostProjectBase(ProjectBase projectBase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProjectBases.Add(projectBase);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProjectBaseExists(projectBase.ProjectBaseId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = projectBase.ProjectBaseId }, projectBase);
        }

        // DELETE: api/ProjectBases/5
        [ResponseType(typeof(ProjectBase))]
        public async Task<IHttpActionResult> DeleteProjectBase(int id)
        {
            ProjectBase projectBase = await db.ProjectBases.FindAsync(id);
            if (projectBase == null)
            {
                return NotFound();
            }

            db.ProjectBases.Remove(projectBase);
            await db.SaveChangesAsync();

            return Ok(projectBase);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProjectBaseExists(int id)
        {
            return db.ProjectBases.Count(e => e.ProjectBaseId == id) > 0;
        }
    }
}