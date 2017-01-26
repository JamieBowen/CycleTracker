using System;
using CycleTracker.Data.Attributes;
using CycleTracker.Data.Models.EnumTypes;

namespace CycleTracker.Data.Models
{
	public class BikePart : CycleTrackerBase
	{
		public DateTime InstalledDate { get; set; }
		public int InstalledBikeMileage { get; set; }
		public BikeArea InstalledBikeArea { get; set; }
		public DateTime? ReplacedDate { get; set; }
		public int? ReplacedBikeMileage { get; set; }
		public decimal PurchasePrice { get; set; }
		public string PurchaseRetailer { get; set; }
		public long RiderBikeId { get; set; }
		public long PartId { get; set; }

		[Ignore]
		public virtual Part Part { get; set; }

		[Ignore]
		public int AccruedMileage => ReplacedBikeMileage.HasValue ? ReplacedBikeMileage.Value - InstalledBikeMileage : 0;

		[Ignore]
		public bool IsCurrentlyInstalled => !ReplacedDate.HasValue;
	}
}
