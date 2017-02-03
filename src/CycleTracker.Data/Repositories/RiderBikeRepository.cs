using System.Data;
using System.Linq;
using CycleTracker.Data.Models;
using CycleTracker.Data.Repositories.Base;
using Dapper;

namespace CycleTracker.Data.Repositories
{
	public interface IRiderBikeRepository : IRepository<RiderBike>
	{
		RiderBike GetWithBike(long id);
		RiderBike GetRiderBikeWithParts(long riderBikeId);
	}

	public class RiderBikeRepository : CycleTrackerBaseRepository<RiderBike>, IRiderBikeRepository
	{
		public RiderBikeRepository() : base("RiderBikes") { }

		public RiderBike GetWithBike(long id)
		{
			const string sql = "SELECT * FROM RiderBikes rb JOIN Bikes b ON b.Id = rb.BikeId where rb.Id = @Id;";
			
			using (IDbConnection cn = CycleTrackerDbConnection())
			{
				return cn.Query<RiderBike, Bike, RiderBike>(sql, MapRiderBike, new {Id = id}).Single();
			}
		}

		public RiderBike GetRiderBikeWithParts(long id)
		{
			const string sql = @"
				SELECT * FROM RiderBikes rb JOIN Bikes b ON b.Id = rb.BikeId where rb.Id = @Id; 
				SELECT * FROM BikeParts bp JOIN Parts p ON p.Id = bp.PartId WHERE bp.RiderBikeId = @Id;	
			";
			RiderBike riderBike = null;

			using (IDbConnection cn = CycleTrackerDbConnection())
			{
				using (var multi = cn.QueryMultiple(sql, new { Id = id }))
				{
					riderBike = multi.Read<RiderBike, Bike, RiderBike>(MapRiderBike).Single();
					riderBike.BikeParts = multi.Read<BikePart, Part, BikePart>(MapBikePart).ToList();
				}
			}

			return riderBike;
		}

		private static RiderBike MapRiderBike(RiderBike riderBike, Bike bike)
		{
			riderBike.Bike = bike;
			return riderBike;
		}

		private static BikePart MapBikePart(BikePart bikePart, Part part)
		{
			bikePart.Part = part;
			return bikePart;
		}
	}
}
