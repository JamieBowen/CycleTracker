using System.Collections.Generic;
using CycleTracker.Data.Attributes;

namespace CycleTracker.Data.Models
{
	public class RiderBike : CycleTrackerBase
	{
		public int Year { get; set; }
		public string Trim { get; set; }
		public string Colors { get; set; }
		public int? Mileage { get; set; }
		public long RiderId { get; set; }
		public long BikeId { get; set; }

		[Ignore]
		public virtual Bike Bike { get; set; }
		[Ignore]
		public virtual List<BikePart> BikeParts { get; set; }
	}
}
