using System.Collections.Generic;
using System.Data;
using System.Linq;
using CycleTracker.Data.Models;
using CycleTracker.Data.Repositories.Base;
using Dapper;

namespace CycleTracker.Data.Repositories
{
	public interface IRiderBikeRepository : IRepository<RiderBike>
	{
		RiderBike GetBikeWithParts(long riderBikeId);
		IEnumerable<RiderBike> GetBikesForRider(long riderId);
	}

	public class RiderBikeRepository : CycleTrackerBaseRepository<RiderBike>, IRiderBikeRepository
	{
		public RiderBikeRepository() : base("RiderBikes") { }
		
		public RiderBike GetBikeWithParts(long id)
		{
			const string sql = @"
				SELECT * FROM RiderBikes rb JOIN Bikes b ON b.Id = rb.BikeId where rb.Id = @Id; 
				SELECT * FROM BikeParts bp JOIN Parts p ON p.Id = bp.PartId WHERE bp.RiderBikeId = @Id;	
			";
			RiderBike data = null;

			// TODO: abstract 'QueryMultiple' logic to base repository
			using (IDbConnection cn = CycleTrackerDbConnection())
			{
				using (var multi = cn.QueryMultiple(sql, new { Id = id }))
				{
					data = multi.Read<RiderBike, Bike, RiderBike>((riderBike, bike) =>
					{
						riderBike.Bike = bike;
						return riderBike;
					}).Single();

					data.BikeParts = multi.Read<BikePart, Part, BikePart>((bikePart, part) =>
					{
						bikePart.Part = part;
						return bikePart;
					}).ToList();
				}
			}

			return data;
		}

		public IEnumerable<RiderBike> GetBikesForRider(long riderId)
		{
			const string sql = "SELECT * FROM RiderBikes rb JOIN Bikes b ON b.Id = rb.BikeId where rb.RiderId = @Id;";
			var param = new { Id = riderId };

			using (IDbConnection cn = CycleTrackerDbConnection())
			{
				return cn.Query(sql, (RiderBike riderBike, Bike bike) =>
				{
					riderBike.Bike = bike;
					return riderBike;
				}, param).AsEnumerable();
			}
		}
	}
}
