using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CycleTracker.API.Controllers
{
    [Route("api/[controller]")]
    public class PartController : Controller
    {
        // GET: api/Part
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

		// GET api/Part/5
		[HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

		// POST api/Part
		[HttpPost]
        public void Post([FromBody]string value)
        {
        }

		// PUT api/Part/5
		[HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

		// DELETE api/Part/5
		[HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
