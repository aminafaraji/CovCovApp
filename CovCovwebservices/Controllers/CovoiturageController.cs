using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TEST.Models;

namespace TEST.Controllers
{
    [Authorize]
    public class CovoiturageController : ApiController
    {
        private CovContext db = new CovContext();

        // GET: api/Covoiturage
        public IQueryable<Covoiturages> GetCovoiturages()
        {
            return db.Covoiturages;
        }

        // GET: api/Covoiturage/CurrentUser
        [Authorize]
        [Route("api/Covoiturage/CurrentUser")]
        public IQueryable<Covoiturages> GetCovoituragesForCurrentUser()
        {

            string userId = User.Identity.GetUserId();
            return db.Covoiturages.Where(cov => cov.UserId == userId);



        }

        // GET: api/Covoiturage/5
        [ResponseType(typeof(Covoiturages))]
        public IHttpActionResult GetCovoiturages(int id)
        {
            Covoiturages covoiturages = db.Covoiturages.Find(id);
            if (covoiturages == null)
            {
                return NotFound();
            }

            return Ok(covoiturages);
        }

        // PUT: api/Covoiturage/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCovoiturages(int id, Covoiturages covoiturages)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != covoiturages.Id)
            {
                return BadRequest();
            }

            db.Entry(covoiturages).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CovoituragesExists(id))
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

        // POST: api/Covoiturage
        [ResponseType(typeof(Covoiturages))]
        public IHttpActionResult PostCovoiturages(Covoiturages covoiturages)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string userId = User.Identity.GetUserId();
            covoiturages.UserId = userId;

            db.Covoiturages.Add(covoiturages);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = covoiturages.Id }, covoiturages);
        }

        // DELETE: api/Covoiturage/5
        [ResponseType(typeof(Covoiturages))]
        public IHttpActionResult DeleteCovoiturages(int id)
        {
            Covoiturages covoiturages = db.Covoiturages.Find(id);
            if (covoiturages == null)
            {
                return NotFound();
            }

            db.Covoiturages.Remove(covoiturages);
            db.SaveChanges();

            return Ok(covoiturages);
        }


         
        // GET: api/Covoiturage/Search/{KeyWord}
        [Route("api/Covoiturage/Search/{KeyWord}")]
        [HttpGet]
        public IQueryable<Covoiturages> SearchCovoiturage(string KeyWord)
        {
            return db.Covoiturages.Where(covoiturage => covoiturage.Depart.Contains(KeyWord)
                                                       || covoiturage.Arrivee.Contains(KeyWord)
            );
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CovoituragesExists(int id)
        {
            return db.Covoiturages.Count(e => e.Id == id) > 0;
        }
    }
}