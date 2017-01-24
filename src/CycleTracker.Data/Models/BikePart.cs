using System;
using CycleTracker.Data.Attributes;

namespace CycleTracker.Data.Models
{
    public class BikePart : CycleTrackerBase
    {
		public DateTime InstalledDate { get; set; }
		public int InstalledBikeMileage { get; set; }
		public DateTime ReplacedDate { get; set; }
		public int ReplacedBikeMileage { get; set; }
		public int AccruedMileage { get; set; }
	    public decimal PurchasePrice { get; set; }
	    public string PurchaseRetailer { get; set; }
		public long RiderBikeId { get; set; }
	    public long PartId { get; set; }

		[Ignore]
		public virtual Part Part { get; set; }
	}
}
