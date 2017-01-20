using CycleTracker.Data.Models;
using CycleTracker.Data.Repositories.Base;

namespace CycleTracker.Data.Repositories
{
	public interface IBikeRepository : IRepository<Bike>
	{
		Bike GetBikeWithBikeParts(long id);
	}

	public class BikeRepository : CycleTrackerBaseRepository<Bike>, IBikeRepository
    {
	    public BikeRepository() : base("Bikes")
	    {
	    }

	    public Bike GetBikeWithBikeParts(long id)
	    {
		    var dbQuery = @"SELECT b.*, p.* 
							FROM Bikes b 
							INNER JOIN BikeParts p
                            ON b.Id = p.BikeId
							WHERE b.Id = @Id";
			
		    return base.FindIncludingList<BikePart>(dbQuery, id);
	    }
    }
}
