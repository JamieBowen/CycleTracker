using System.Collections.Generic;
using CycleTracker.Data.Models;
using CycleTracker.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CycleTracker.API.Controllers
{
    [Route("api/[controller]")]
    public class PartController : Controller
    {
	    private readonly IPartRepository partRepository;
	    public PartController(IPartRepository partRepository)
	    {
		    this.partRepository = partRepository;
	    }

	    // GET: api/Part
        [HttpGet]
        public IEnumerable<Part> Get()
        {
            return partRepository.FindAll();
        }

		// GET api/Part/5
		[HttpGet("{id}")]
        public Part Get(long id)
        {
            return partRepository.FindById(id);
        }

		// POST api/Part
		[HttpPost]
        public Part Post([FromBody]Part value)
		{
			var id = partRepository.Add(value);
			return partRepository.FindById(id);
		}

		// PUT api/Part/5
		[HttpPut]
        public void Put([FromBody]Part value)
        {
			partRepository.Update(value);
        }

		// DELETE api/Part/5
		[HttpDelete("{id}")]
        public void Delete(long id)
        {
			partRepository.Remove(id);
        }
    }
}
