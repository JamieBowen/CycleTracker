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
	}

	public class RiderBikeRepository : CycleTrackerBaseRepository<RiderBike>, IRiderBikeRepository
	{
		public RiderBikeRepository() : base("RiderBikes") { }
		
		public RiderBike GetBikeWithParts(long id)
		{
			const string sql = @"
				SELECT * FROM RiderBikes rb JOIN Bikes b ON b.Id = rb.BikeId where rb.Id = @id; 
				SELECT * FROM BikeParts bp JOIN Parts p ON p.Id = bp.PartId WHERE bp.RiderBikeId = @id;	
			";
			RiderBike data = null;

			// TODO: abstract 'QueryMultiple' logic to base repository
			using (IDbConnection cn = CycleTrackerDbConnection())
			{

				using (var multi = cn.QueryMultiple(sql, new { id = id }))
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
	}
}
