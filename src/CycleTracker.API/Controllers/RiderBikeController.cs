using System.Collections.Generic;
using CycleTracker.Data.Models;
using CycleTracker.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CycleTracker.API.Controllers
{
	[Route("api/[controller]")]
	public class RiderBikeController : Controller
	{
		private readonly IRiderBikeRepository _riderBikeRepository;

		public RiderBikeController(IRiderBikeRepository riderBikeRepository)
		{
			_riderBikeRepository = riderBikeRepository;
		}
		
		// GET: api/RiderBike
		[HttpGet]
		public IEnumerable<RiderBike> Get()
		{
			return _riderBikeRepository.FindAll();
		}

		// GET api/RiderBike/5
		[HttpGet("{id}")]
		public RiderBike Get(long id)
		{
			return _riderBikeRepository.FindById(id);
		}

		[HttpGet("forRider/{riderId}")]
		public IEnumerable<RiderBike> GetForRider(long riderId)
		{
			return _riderBikeRepository.GetBikesForRider(riderId);
		}

		// GET api/RiderBike/5/parts
		[HttpGet("{id}/parts")]
		public RiderBike GetWithParts(long id)
		{
			return _riderBikeRepository.GetBikeWithParts(id);
		}

		// POST api/RiderBike
		[HttpPost]
		public RiderBike Post([FromBody]RiderBike value)
		{
			var id = _riderBikeRepository.Add(value);
			return _riderBikeRepository.FindById(id);
		}

		// PUT api/RiderBike/5
		[HttpPut]
		public void Put([FromBody]RiderBike value)
		{
			_riderBikeRepository.Update(value);
		}
	}
}
