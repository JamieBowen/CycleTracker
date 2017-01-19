using CycleTracker.Data.Attributes;
using System.Collections.Generic;

namespace CycleTracker.Data.Models
{
	public class Bike : CycleTrackerBase
	{
		public int RiderId { get; set; }
		public string Make { get; set; }
		public string Model { get; set; }
		public int Year { get; set; }
		public string Trim { get; set; }
		public string Colors { get; set; }

		[Ignore]
		public virtual Rider Rider { get; set; }

		[Ignore]
		public virtual List<BikePart> BikeParts { get; set; }
	}
}
