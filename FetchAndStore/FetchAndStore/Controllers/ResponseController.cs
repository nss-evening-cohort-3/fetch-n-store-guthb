using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FetchAndStore.DAL;
using FetchAndStore.Models;



namespace FetchAndStore.Controllers
{
    public class ResponseController : ApiController
    {
        // GET api/<controller>
        
        public List<Response> Get()
        {
            ResponseRepository repo = new ResponseRepository();
            return repo.GetResponses();
        }
        

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        
        public void  Post(Response _response)
        {
            ResponseRepository repo = new ResponseRepository();
            repo.AddResponse(_response);
            
        }

        
        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            ResponseRepository repo = new ResponseRepository();
            repo.RemoveResponse(id);

        }
    }
}