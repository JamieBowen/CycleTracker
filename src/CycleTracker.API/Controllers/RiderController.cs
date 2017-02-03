using System.Collections.Generic;
using CycleTracker.Data.Models;
using CycleTracker.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CycleTracker.API.Controllers
{
	[Route("api/[controller]")]
	public class RiderController : Controller
	{
		private readonly IRiderRepository _riderRepository;

		public RiderController(IRiderRepository riderRepository)
		{
			this._riderRepository = riderRepository;
		}
		
		// GET: api/Rider
		[HttpGet]
		public IEnumerable<Rider> Get()
		{
			return _riderRepository.FindAll();
		}

		// GET api/Rider/5
		[HttpGet("{id}")]
		public RiderViewModel Get(long id)
		{
			var rider = _riderRepository.FindById(id);
			return RiderViewModel.FromRider(rider);
		}

		// GET api/Rider/5/bikes
		[HttpGet("{id}/bikes")]
		public RiderViewModel GetWithBikes(long id)
		{
			var rider = _riderRepository.GetRiderWithBikes(id);
			return RiderViewModel.FromRider(rider);
		}
		
		// POST api/Rider
		[HttpPost]
		public Rider Post([FromBody]Rider value)
		{
			var id = _riderRepository.Add(value);
			return _riderRepository.FindById(id);
		}

		// PUT api/Rider/5
		[HttpPut]
		public void Put([FromBody]Rider value)
		{
			_riderRepository.Update(value);
		}

		// DELETE api/Rider/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			_riderRepository.Remove(id);
		}
	}
}
