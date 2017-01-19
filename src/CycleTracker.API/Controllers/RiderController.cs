using System.Collections.Generic;
using CycleTracker.Data.Models;
using CycleTracker.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CycleTracker.API.Controllers
{
	[Route("api/[controller]")]
	public class RiderController : Controller
	{
		private readonly IRiderRepository riderRepository;

		public RiderController(IRiderRepository riderRepository)
		{
			this.riderRepository = riderRepository;
		}
		
		// GET: api/Rider
		[HttpGet]
		public IEnumerable<Rider> Get()
		{
			return riderRepository.FindAll();
		}

		// GET api/Rider/5
		[HttpGet("{id}")]
		public Rider Get(long id)
		{
			return riderRepository.FindById(id);
		}
		
		// POST api/Rider
		[HttpPost]
		public Rider Post([FromBody]Rider value)
		{
			var id = riderRepository.Add(value);
			return riderRepository.FindById(id);
		}

		// PUT api/Rider/5
		[HttpPut]
		public void Put([FromBody]Rider value)
		{
			riderRepository.Update(value);
		}

		// DELETE api/Rider/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			riderRepository.Remove(id);
		}
	}
}
