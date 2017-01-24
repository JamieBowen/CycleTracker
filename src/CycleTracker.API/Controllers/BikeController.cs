using System;
using System.Collections.Generic;
using CycleTracker.Data.Models;
using CycleTracker.Data.Models.EnumTypes;
using CycleTracker.Data.Repositories;
using CycleTracker.Data.Repositories.Base;
using Microsoft.AspNetCore.Mvc;

namespace CycleTracker.API.Controllers
{
	[Route("api/[controller]")]
	public class BikeController : Controller
	{
		private readonly IBikeRepository bikeRepository;

		public BikeController(IBikeRepository bikeRepository)
		{
			this.bikeRepository = bikeRepository;
		}

		// GET: api/Bike/init
		[HttpGet("init")]
		public IEnumerable<Bike> GetInit()
		{
			var riderRepo = new RiderRepository();
			var riderBikeRepo = new RiderBikeRepository();
			var partRepo = new PartRepository();
			var bikePartRepo = new BikePartRepository();

			var jamie = InitRider(riderRepo, "jamie@cycletracker.com", "Bowen", "Jamie");
			var roubaix = InitBike(bikeRepository, "Specialized", "Roubaix");
			var trek = InitBike(bikeRepository, "Trek", "7500");
			var jamiesRoubaix = InitRiderBike(riderBikeRepo, jamie, roubaix, "Black/Red", "SL2", 2013);
			var jamiesTrek = InitRiderBike(riderBikeRepo, jamie, trek, "Black/Silver", "", 2011);
			
			var jeff = InitRider(riderRepo, "jeff@cycletracker.com", "Beck", "Jeff");
			var stumpJumper = InitBike(bikeRepository, "Specialized", "Stumpjumper FSR Evo");
			var jeffsStumpJumper = InitRiderBike(riderBikeRepo, jeff, stumpJumper, "Black/Yellow", "Comp 650b", 2015);
			
			var frontHub = InitPart(partRepo, PartType.FrontHub, "Blue", "Pro4", "Hope", 199.90M);
			var rearHub = InitPart(partRepo, PartType.RearHub, "Blue", "Pro4", "Hope", 199.90M);
			
			InitBikePart(bikePartRepo, jeffsStumpJumper, frontHub, DateTime.UtcNow, 3, 180.00M, "Chain Reaction Cycles");
			InitBikePart(bikePartRepo, jeffsStumpJumper, rearHub, DateTime.UtcNow, 3, 180.00M, "Chain Reaction Cycles");

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

		// GET api/Bike/5/parts
		[HttpGet("{id}/parts")]
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

		private static Rider InitRider(IRiderRepository repository, string email, string lastName, string firstName)
		{
			var rider = new Rider { Email = email, LastName = lastName, FirstName = firstName };
			repository.Add(rider);
			return rider;
		}

		private static Bike InitBike(IBikeRepository repository, string make, string model)
		{
			var bike = new Bike { Make = make, Model = model };
			repository.Add(bike);
			return bike;
		}

		private static RiderBike InitRiderBike(IRiderBikeRepository repository, Rider rider, Bike bike, string colors, string trim, int year)
		{
			var riderBike = new RiderBike { RiderId = rider.Id, BikeId = bike.Id, Colors = colors, Trim = trim, Year = year };
			repository.Add(riderBike);
			return riderBike;
		}
		
		private static Part InitPart(IPartRepository repository, PartType partType, string description, string model, string manufacturer, decimal price)
		{
			var part = new Part
			{
				PartType = partType,
				Description = description,
				Model = model,
				Manufacturer = manufacturer,
				Price = price
			};
			repository.Add(part);
			return part;
		}

		private static BikePart InitBikePart(BikePartRepository repository, RiderBike riderBike, Part part, DateTime installedDate, int installedMileage, decimal purchasePrice, string purchaseRetailer)
		{
			var bikePart = new BikePart
			{
				RiderBikeId = riderBike.Id,
				PartId = part.Id,
				InstalledDate = installedDate,
				InstalledBikeMileage = installedMileage,
				PurchasePrice = purchasePrice,
				PurchaseRetailer = purchaseRetailer
			};
			repository.Add(bikePart);
			return bikePart;
		}
		
	}
}
