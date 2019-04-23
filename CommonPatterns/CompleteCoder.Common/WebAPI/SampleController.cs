using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteCoder.Common.WebAPI
{
    public class ApplicationsController : ApiController
    {
        private IRepository<SampleModel> Repository;
        public ApplicationsController(IRepository<SampleModel> repository)
        {
            this.Repository = repository;
        }

        // GET: api/Applications
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);

            try
            {
                return Ok(Repository.Collection());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }

        // GET: api/Applications/5
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);

            try
            {
                return Ok(Repository.Find(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }

        }

        // POST: api/Applications
        [HttpPost]
        public IHttpActionResult Post([FromBody]SampleModel newObject)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);

            try
            {
                Repository.Insert(newObject);
                Repository.Commit();

                return Ok(newObject); //return the object back with the new Id
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult Put(SampleModel updatedObject)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);

            try
            {
                Repository.Update(updatedObject);
                Repository.Commit();
                return Ok(updatedObject);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }

        }

        [HttpDelete]
        public IHttpActionResult Delete(string Id)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);

            try
            {
                Repository.Delete(Id);
                Repository.Commit();

                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }

        }
    }
}

