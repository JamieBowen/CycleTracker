namespace CycleTracker.Data.Models
{
	public class Bike : CycleTrackerBase
	{
		public string Make { get; set; }
		public string Model { get; set; }
		public int Year { get; set; }
		public string Trim { get; set; }
		public string Colors { get; set; }
	}
}
