using CycleTracker.Data.Models;
using CycleTracker.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CycleTracker.API.Controllers
{
    [Route("api/[controller]")]
    public class BikePartController : Controller
    {
	    private readonly IBikePartRepository bikePartRepository;

	    public BikePartController(IBikePartRepository bikePartRepository)
	    {
		    this.bikePartRepository = bikePartRepository;
	    }

	    // GET api/bikepart/5
		[HttpGet("{id}")]
        public BikePart Get(long id)
        {
            return bikePartRepository.GetBikePartWithPart(id);
        }

		// POST api/bikepart
		[HttpPost]
        public BikePart Post([FromBody]BikePart value)
		{
			var bikePartId = bikePartRepository.Add(value);
			return bikePartRepository.FindById(bikePartId);
		}

		// PUT api/bikepart/5
		[HttpPut("{id}")]
        public void Put([FromBody]BikePart value)
        {
			bikePartRepository.Update(value);
        }

		// DELETE api/bikepart/5
		[HttpDelete("{id}")]
        public void Delete(long id)
        {
			bikePartRepository.Remove(id);
        }
    }
}
