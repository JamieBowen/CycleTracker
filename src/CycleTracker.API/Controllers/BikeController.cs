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
			var riderRepo = new RiderRepository();
			var partRepo = new PartRepository();
			var bikePartRepo = new BikePartRepository();

			var jamie = InitRiderJamie();
			riderRepo.Add(jamie);

			var roubaix = InitBikeRoubaix(jamie);
			bikeRepository.Add(roubaix);
			
			var jeff = InitRiderJeff();
			riderRepo.Add(jeff);

			var stumpJumper = InitBikeStumpJumper(jeff);
			stumpJumper.Id = bikeRepository.Add(stumpJumper);
			
			partRepo.Add(InitPartFrontHub());
			partRepo.Add(InitPartRearHub());

			var parts = partRepo.FindAll();

			foreach (var part in parts)
			{
				var bikePart = InitBikePart(stumpJumper, part);
				bikePartRepo.Add(bikePart);
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


		private static BikePart InitBikePart(Bike bike, Part part)
		{
			return new BikePart { BikeId = bike.Id, PartId = part.Id, InstalledDate = DateTime.UtcNow, InstalledBikeMileage = 3, PurchasePrice = 180.00M, PurchaseRetailer = "Chain Reaction Cycles" };
		}

		private static Part InitPartRearHub()
		{
			return new Part { PartType = PartType.RearHub, Description = "Blue", Model = "Pro4", Manufacturer = "Hope", Price = 199.90M };
		}

		private static Part InitPartFrontHub()
		{
			return new Part { PartType = PartType.FrontHub, Description = "Blue", Model = "Pro4", Manufacturer = "Hope", Price = 199.90M };
		}

		private static Bike InitBikeStumpJumper(Rider jeff)
		{
			return new Bike { RiderId = jeff.Id, Make = "Specialized", Model = "Stumpjumper FSR Evo", Colors = "Black / Yellow", Trim = "Comp 650b", Year = 2015 };
		}

		private static Rider InitRiderJeff()
		{
			return new Rider { Email = "jeff@cycletracker.com", LastName = "Beck", FirstName = "Jeff" };
		}

		private static Bike InitBikeRoubaix(Rider jamie)
		{
			return new Bike { RiderId = jamie.Id, Make = "Specialized", Model = "Roubaix", Trim = "SL2", Colors = "Black/Red", Year = 2013 };
		}

		private static Rider InitRiderJamie()
		{
			return new Rider { Email = "jamie@cycletracker.com", LastName = "Bowen", FirstName = "Jamie" };
		}
	}
}
