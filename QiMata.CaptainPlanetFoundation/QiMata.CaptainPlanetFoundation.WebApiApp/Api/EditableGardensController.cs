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
    public class EditableGardensController : ApiController
    {
        private CaptainContext db = new CaptainContext();

        // GET: api/EditableGardens
        public IQueryable<EditableGarden> GetEditableGardens()
        {
            return db.EditableGardens.Include(x => x.ProjectBase);
        }

        // GET: api/EditableGardens/5
        [ResponseType(typeof(EditableGarden))]
        public async Task<IHttpActionResult> GetEditableGarden(int id)
        {
            EditableGarden editableGarden = await db.EditableGardens.FindAsync(id);
            if (editableGarden == null)
            {
                return NotFound();
            }

            return Ok(editableGarden);
        }

        // PUT: api/EditableGardens/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEditableGarden(int id, EditableGarden editableGarden)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != editableGarden.EditableGardenId)
            {
                return BadRequest();
            }

            db.Entry(editableGarden).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EditableGardenExists(id))
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

        // POST: api/EditableGardens
        [ResponseType(typeof(EditableGarden))]
        public async Task<IHttpActionResult> PostEditableGarden(EditableGarden editableGarden)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EditableGardens.Add(editableGarden);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EditableGardenExists(editableGarden.EditableGardenId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = editableGarden.EditableGardenId }, editableGarden);
        }

        // DELETE: api/EditableGardens/5
        [ResponseType(typeof(EditableGarden))]
        public async Task<IHttpActionResult> DeleteEditableGarden(int id)
        {
            EditableGarden editableGarden = await db.EditableGardens.FindAsync(id);
            if (editableGarden == null)
            {
                return NotFound();
            }

            db.EditableGardens.Remove(editableGarden);
            await db.SaveChangesAsync();

            return Ok(editableGarden);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EditableGardenExists(int id)
        {
            return db.EditableGardens.Count(e => e.EditableGardenId == id) > 0;
        }
    }
}