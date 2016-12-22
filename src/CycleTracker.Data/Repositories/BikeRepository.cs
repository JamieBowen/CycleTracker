using CycleTracker.Data.Models;

namespace CycleTracker.Data.Repositories
{
    public class BikeRepository : CycleTrackerBaseRepository<Bike>
    {
	    public BikeRepository() : base("Bikes")
	    {
	    }
    }
}
