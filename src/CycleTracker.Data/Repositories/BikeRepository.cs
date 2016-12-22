using CycleTracker.Data.Models;

namespace CycleTracker.Data.Repositories
{
	public interface IBikeRepository : Repositories.IRepository<Bike>
	{
	}

	public class BikeRepository : CycleTrackerBaseRepository<Bike>, IBikeRepository
    {
	    public BikeRepository() : base("Bikes")
	    {
	    }
    }
}
