using System.Collections.Generic;
using CycleTracker.Data.Attributes;

namespace CycleTracker.Data.Models
{
    public class Rider : CycleTrackerBase
	{
		public string Email { get; set; }
		public string LastName { get; set; }
		public string FirstName { get; set; }

		[Ignore]
		public virtual List<RiderBike> RiderBikes { get; set; }
    }
}
