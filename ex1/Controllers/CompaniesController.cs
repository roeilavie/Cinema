using ex1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ex1.Controllers
{
    public class CompaniesController : ApiController
    {
        // GET api/<controller>
        public List<Company> Get()
        {
            Company comp = new Company();
            return comp.Read();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public Company Post(Company company)
        {
            Company cmp = company.Insert();
            return cmp;
        }

        // PUT api/<controller>/5
        public List<Company> Put(Company comp)
        {
            comp.Update();
            return comp.Read();
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        [Route("api/Companies/{user_name}")]
        public List<Company> Delete(string user_name)
        {
            Company company = new Company();
            company.Delete(user_name);
            return company.Read();
        }
    }
}