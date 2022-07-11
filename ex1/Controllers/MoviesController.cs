using ex1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ex1.Controllers
{
    public class MoviesController : ApiController
    {
        // GET api/<controller>
        public List<Movie> Get()
        {
            Movie m = new Movie();
            List<Movie> movies = m.Read();
            return movies;
        }

        [HttpGet]
        [Route("api/Movies/{id}")]
        // GET api/<controller>/5
        public Movie Get(int id)
        {
            Movie m = new Movie();
            Movie movie = m.Read(id);
            return movie;
        }

        [HttpPost]
        [Route("api/Movies/{movie_D}/Post/{user_name}")]
        // POST api/<controller>
        public Movie Post(Movie movie, string user_name)
        {
            Movie m = movie.Insert();
            movie.Insert(user_name);
            return m;
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}