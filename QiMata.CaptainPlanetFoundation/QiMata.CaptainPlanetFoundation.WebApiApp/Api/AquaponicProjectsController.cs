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
    public class AquaponicProjectsController : ApiController
    {
        private CaptainContext db = new CaptainContext();

        // GET: api/AquaponicProjects
        public IQueryable<AquaponicProject> GetAquaponicProjects()
        {
            return db.AquaponicProjects.Include(x=> x.ProjectBase);
        }

        // GET: api/AquaponicProjects/5
        [ResponseType(typeof(AquaponicProject))]
        public async Task<IHttpActionResult> GetAquaponicProject(int id)
        {
            AquaponicProject aquaponicProject = await db.AquaponicProjects.FindAsync(id);
            if (aquaponicProject == null)
            {
                return NotFound();
            }

            return Ok(aquaponicProject);
        }

        // PUT: api/AquaponicProjects/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAquaponicProject(int id, AquaponicProject aquaponicProject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aquaponicProject.AquaponicProjectId)
            {
                return BadRequest();
            }

            db.Entry(aquaponicProject).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AquaponicProjectExists(id))
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

        // POST: api/AquaponicProjects
        [ResponseType(typeof(AquaponicProject))]
        public async Task<IHttpActionResult> PostAquaponicProject(AquaponicProject aquaponicProject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (aquaponicProject.ProjectBase != null)
            {
                aquaponicProject.ProjectBase.DateReported = DateTime.Now;
            }
            db.AquaponicProjects.Add(aquaponicProject);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AquaponicProjectExists(aquaponicProject.AquaponicProjectId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = aquaponicProject.AquaponicProjectId }, aquaponicProject);
        }

        // DELETE: api/AquaponicProjects/5
        [ResponseType(typeof(AquaponicProject))]
        public async Task<IHttpActionResult> DeleteAquaponicProject(int id)
        {
            AquaponicProject aquaponicProject = await db.AquaponicProjects.FindAsync(id);
            if (aquaponicProject == null)
            {
                return NotFound();
            }

            db.AquaponicProjects.Remove(aquaponicProject);
            await db.SaveChangesAsync();

            return Ok(aquaponicProject);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AquaponicProjectExists(int id)
        {
            return db.AquaponicProjects.Count(e => e.AquaponicProjectId == id) > 0;
        }
    }
}