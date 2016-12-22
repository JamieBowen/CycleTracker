using System.Collections.Generic;
using System.Data;
using System.Linq;
using CycleTracker.Data.Models;
using CycleTracker.Data.Repositories.Base;
using Dapper;

namespace CycleTracker.Data.Repositories
{
	public interface IBikeRepository : IRepository<Bike>
	{
		IEnumerable<Bike> GetBikeWithParts(long id);
	}

	public class BikeRepository : CycleTrackerBaseRepository<Bike>, IBikeRepository
    {
	    public BikeRepository() : base("Bikes")
	    {
	    }

	    public IEnumerable<Bike> GetBikeWithParts(long id)
	    {
		    var dbQuery = @"SELECT b.*, p.* 
							FROM Bikes b 
							INNER JOIN Parts p
                            ON b.Id = p.BikeId
							WHERE b.Id = @Id";

			var bikeLookup = new Dictionary<long, Bike>();
		    IEnumerable<Bike> bikeList = new List<Bike>();

			using (IDbConnection cn = CycleTrackerDbConnection())
			{
				cn.Open();
				bikeList = cn.Query<Bike, Part, Bike>(dbQuery, (Bike bke, Part prt)=>
				{
					Bike bike;

					if (!bikeLookup.TryGetValue(bke.Id, out bike))
					{
						bikeLookup.Add(bke.Id, bike = bke);
					}

					if (bike.BikeParts == null)
					{
						bike.BikeParts = new List<Part>();
					}

					bike.BikeParts.Add(prt);

					return bike;
				},
				new { Id = id }
				).AsEnumerable();
			}
			
			return bikeList;
		}
    }
}
