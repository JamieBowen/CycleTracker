using CycleTracker.Data.Attributes;
using System.Collections.Generic;

namespace CycleTracker.Data.Models
{
	public class Bike : CycleTrackerBase
	{
		public string Make { get; set; }
		public string Model { get; set; }
		public int Year { get; set; }
		public string Trim { get; set; }
		public string Colors { get; set; }
		[Ignore]
		public virtual List<Part> BikeParts { get; set; }
	}
}
