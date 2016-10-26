using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FetchAndStore.Models;


namespace FetchAndStore.DAL
{
    public class ResponseRepository
    {

        public ResponseContext Context { get; set; }

        public ResponseRepository()
        {
            Context = new ResponseContext();
        }

        public ResponseRepository(ResponseContext _context)
        {
            Context = _context;
        }

        public List<Response> GetResponses()
        {
            return Context.Responses.ToList();
        }
        public void AddResponse(Response _response)
        {
            Context.Responses.Add(_response);
            Context.SaveChanges();
        }


    }
}