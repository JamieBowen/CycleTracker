using CycleTracker.Data.Helpers;
using CycleTracker.Data.Models;
using CycleTracker.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CycleTracker.API.Controllers
{
	[Route("api/[controller]")]
	public class BikeController : Controller
	{
		private readonly IBikeRepository _bikeRepository;
		private readonly IRiderBikeRepository _riderBikeRepository;

		public BikeController(IBikeRepository bikeRepository, IRiderBikeRepository riderBikeRepository)
		{
			_bikeRepository = bikeRepository;
			_riderBikeRepository = riderBikeRepository;
		}

		// POST: api/Bike/init
		[HttpPost("init")]
		public void GetInit()
		{
			DataInitializer.Initialize();
		}
		
		// GET api/Bike/5
		[HttpGet("{id}")]
		public BikeViewModel Get(long id)
		{
			var riderBike = _riderBikeRepository.GetWithBike(id);
			return BikeViewModel.FromRiderBike(riderBike);
		}

		// GET api/Bike/5/parts
		[HttpGet("{id}/parts")]
		public BikeViewModel GetWithParts(long id)
		{
			var riderBike = _riderBikeRepository.GetRiderBikeWithParts(id);
			return BikeViewModel.FromRiderBike(riderBike);
		}

		//// POST api/Bike
		//[HttpPost]
		//public RiderBike Post([FromBody]RiderBike value)
		//{
		//	var id = _riderBikeRepository.Add(value);
		//	return _riderBikeRepository.FindById(id);
		//}

		//// PUT api/Bike/5
		//[HttpPut]
		//public void Put([FromBody]Bike value)
		//{
		//	_bikeRepository.Update(value);
		//}

		//// DELETE api/Bike/5
		//[HttpDelete("{id}")]
		//public void Delete(int id)
		//{
		//	_bikeRepository.Remove(id);
		//}

	}
}
