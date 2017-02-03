using System.Collections.Generic;

namespace CycleTracker.Data.Models
{
    public class BikeViewModel 
	{
		public long Id { get; set; }
		public string Make { get; set; }
		public string Model { get; set; }
		public int Year { get; set; }
		public string Trim { get; set; }
		public string Colors { get; set; }
		public int? Mileage { get; set; }
		public List<BikePart> BikeParts { get; set; }

		public static BikeViewModel FromRiderBike(RiderBike riderBike)
		{
			return new BikeViewModel
			{
				Id = riderBike.Id,
				Make = riderBike.Bike?.Make,
				Model = riderBike.Bike?.Model,
				Trim = riderBike.Trim,
				Year = riderBike.Year,
				Colors = riderBike.Colors,
				Mileage = riderBike.Mileage,
				BikeParts = riderBike.BikeParts,
			};
		}
	}
}
