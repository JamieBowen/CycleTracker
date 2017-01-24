using System.Collections.Generic;
using CycleTracker.Data.Models;
using CycleTracker.Data.Repositories.Base;

namespace CycleTracker.Data.Repositories
{
	public interface IBikePartRepository : IRepository<BikePart>
	{
		IEnumerable<BikePart> GetBikePartsByBike(long bikeId);
		BikePart GetBikePartWithPart(long bikePartId);
		IEnumerable<BikePart> GetBikePartsByBikeWithPart(long bikeId);
	}
	public class BikePartRepository : CycleTrackerBaseRepository<BikePart>, IBikePartRepository
	{
		public BikePartRepository() : base("BikeParts")
	    {
		}

		public IEnumerable<BikePart> GetBikePartsByBike(long riderBikeId)
		{
			return base.Find(part => part.RiderBikeId == riderBikeId);
		}

		public BikePart GetBikePartWithPart(long bikePartId)
		{
			var dbQuery = @"SELECT bp.*, p.* 
							FROM BikeParts bp 
							INNER JOIN Parts p
                            ON bp.PartId = p.Id
							WHERE bp.Id = @Id";

			return FindIncluding<Part>(dbQuery, bikePartId);
		}

		public IEnumerable<BikePart> GetBikePartsByBikeWithPart(long bikeId)
		{
			var dbQuery = @"SELECT bp.*, p.* 
							FROM BikeParts bp 
							INNER JOIN Parts p
                            ON bp.PartId = p.Id";

			return FindAllIncluding<Part>(dbQuery);
		}
	}
}
