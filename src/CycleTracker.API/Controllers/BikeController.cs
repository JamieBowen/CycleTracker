using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CycleTracker.Data.Models;
using CycleTracker.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CycleTracker.API.Controllers
{
    [Route("api/[controller]")]
    public class BikeController : Controller
    {
	    private readonly IBikeRepository bikeRepository;

	    public BikeController(Data.Repositories.IBikeRepository bikeRepository)
	    {
		    this.bikeRepository = bikeRepository;
	    }

	    // GET: api/values
        [HttpGet]
        public IEnumerable<Bike> Get()
        {
			return bikeRepository.FindAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Bike Get(long id)
        {
            return bikeRepository.FindById(id);
        }

        // POST api/values
        [HttpPost]
        public Bike Post([FromBody]Bike value)
        {
	        var id = bikeRepository.Add(value);
	        return bikeRepository.FindById(id);
        }

        // PUT api/values/5
        [HttpPut]
        public void Put([FromBody]Bike value)
        {
			bikeRepository.Update(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
			bikeRepository.Remove(id);
        }
    }
}
