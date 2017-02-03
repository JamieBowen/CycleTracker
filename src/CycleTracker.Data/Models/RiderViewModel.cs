using System.Collections.Generic;
using System.Linq;

namespace CycleTracker.Data.Models
{
    public class RiderViewModel
    {
		public long Id { get; set; }
		public string Email { get; set; }
		public string LastName { get; set; }
		public string FirstName { get; set; }

		public virtual List<BikeViewModel> Bikes { get; set; }

	    public static RiderViewModel FromRider(Rider rider)
	    {
		    return new RiderViewModel
		    {
				Id = rider.Id,
				Email = rider.Email,
				LastName = rider.LastName,
				FirstName = rider.FirstName,
				Bikes = rider.RiderBikes?.Select(BikeViewModel.FromRiderBike).ToList()
		    };
	    }
	}
}
