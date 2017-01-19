using CycleTracker.Data.Models;
using CycleTracker.Data.Repositories.Base;

namespace CycleTracker.Data.Repositories
{
	public interface IRiderRepository : IRepository<Rider>
	{
	}

	public class RiderRepository : CycleTrackerBaseRepository<Rider>, IRiderRepository
	{
		public RiderRepository() : base("Riders") { }
	}
}
