using System.Collections.Generic;
using System.Data;
using System.Linq;
using CycleTracker.Data.Models;
using CycleTracker.Data.Repositories.Base;
using Dapper;

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
			const string sql = @"
				SELECT * FROM Riders where Id = @id; 
				SELECT * FROM RiderBikes rb JOIN Bikes b ON b.Id = rb.BikeId WHERE rb.RiderId = @id;	
			";
			Rider rider = null;

			// TODO: abstract 'QueryMultiple' logic to base repository
			using (IDbConnection cn = CycleTrackerDbConnection())
			{

				using (var multi = cn.QueryMultiple(sql, new {id = id}))
				{
					rider = multi.ReadSingle<Rider>();
					rider.RiderBikes = multi.Read<RiderBike, Bike, RiderBike>((riderBike, bike) =>
					{
						riderBike.Bike = bike;
						return riderBike;
					}).ToList();
				}
			}

			return rider;
		}
	}
}
