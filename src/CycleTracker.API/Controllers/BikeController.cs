using System;
using System.Collections.Generic;
using CycleTracker.Data.Models;
using CycleTracker.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

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

		// GET: api/Bike/init
		[HttpGet("init")]
		public IEnumerable<Bike> GetInit()
		{
			var partRepo = new PartRepository();
			var bike = new Bike { Make = "Specialized", Model = "Stumpjumper", Colors = "Black / Green", Trim = " FSR Evo Comp 650b", Year = 2015 };

			bike.Id = bikeRepository.Add(bike);

			var part = new Part { BikeId = bike.Id, Description = "Hope Pro 4 with Stans No Tubes ZTR Hoops", InstalledBikeMileage = 3, InstalledDate = DateTime.UtcNow, Retailer = "Eddy's", Name = "Front Wheel" };

			partRepo.Add(part);

			part = new Part { BikeId = bike.Id, Description = "Hope Pro 4 with Stans No Tubes ZTR Hoops", InstalledBikeMileage = 3, InstalledDate = DateTime.UtcNow, Retailer = "Eddy's", Name = "Rear Wheel" };

			partRepo.Add(part);

			return bikeRepository.FindAll();
		}

		// GET: api/Bike
		[HttpGet]
        public IEnumerable<Bike> Get()
        {
			return bikeRepository.FindAll();
        }

		// GET api/Bike/5
		[HttpGet("{id}")]
        public Bike Get(long id)
        {
            return bikeRepository.FindById(id);
        }

		// GET api/Bike/withparts/5
		[HttpGet("withparts/{id}")]
		public Bike GetWithParts(long id)
		{
			return bikeRepository.GetBikeWithParts(id);
		}

		// POST api/Bike
		[HttpPost]
        public Bike Post([FromBody]Bike value)
        {
	        var id = bikeRepository.Add(value);
	        return bikeRepository.FindById(id);
        }

		// PUT api/Bike/5
		[HttpPut]
        public void Put([FromBody]Bike value)
        {
			bikeRepository.Update(value);
        }

		// DELETE api/Bike/5
		[HttpDelete("{id}")]
        public void Delete(int id)
        {
			bikeRepository.Remove(id);
        }
    }
}
