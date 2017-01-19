using CycleTracker.Data.Attributes;
using System.Collections.Generic;

namespace CycleTracker.Data.Models
{
	public class Bike : CycleTrackerBase
	{
		public string Make { get; set; }
		public string Model { get; set; }
	}
}
