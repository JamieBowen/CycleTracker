using System;
using System.Collections.Generic;
using CycleTracker.Data.Models;
using CycleTracker.Data.Models.EnumTypes;
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
			var bikePartRepo = new BikePartRepository();
			var bike = new Bike { Make = "Specialized", Model = "Stumpjumper FSR Evo", Colors = "Black / Yellow", Trim = "Comp 650b", Year = 2015 };

			bike.Id = bikeRepository.Add(bike);

			var part = new Part
			{
				PartType = PartType.FrontHub,
				Description = "Blue",
				Model = "Pro4",
				Manufacturer = "Hope",
				Price = 199.90M
			};

			partRepo.Add(part);

			part = new Part
			{
				PartType = PartType.RearHub,
				Description = "Blue",
				Model = "Pro4",
				Manufacturer = "Hope",
				Price = 199.90M
			};

			partRepo.Add(part);

			var parts = partRepo.FindAll();

			foreach (var prt in parts)
			{
				var bkePart = new BikePart()
				{
					BikeId = bike.Id,
					PartId = prt.Id,
					InstalledDate = DateTime.UtcNow,
					InstalledBikeMileage = 3,
					PurchasePrice = 180.00M,
					PurchaseRetailer = "Chain Reaction Cycles"
				};

				bikePartRepo.Add(bkePart);
			}

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
			return bikeRepository.GetBikeWithBikeParts(id);
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
