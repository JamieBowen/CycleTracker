using CycleTracker.Data.Models;
using CycleTracker.Data.Repositories.Base;

namespace CycleTracker.Data.Repositories
{
	public interface IRiderRepository : IRepository<Rider>
	{
		Rider GetRiderWithBikes(long id);
	}

	public class RiderRepository : CycleTrackerBaseRepository<Rider>, IRiderRepository
	{
		public RiderRepository() : base("Riders") { }

		public Rider GetRiderWithBikes(long id)
		{
			var dbQuery = @"SELECT r.*, b.* 
							FROM Riders r 
							INNER JOIN Bikes b
                            ON r.Id = b.RiderId
							WHERE r.Id = @Id";

			return base.FindIncludingList<Bike>(dbQuery, id);
		}
	}
}
