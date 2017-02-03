using System;
using CycleTracker.Data.Models;
using CycleTracker.Data.Models.EnumTypes;
using CycleTracker.Data.Repositories;

namespace CycleTracker.Data.Helpers
{
    public static class DataInitializer
    {
		public static void Initialize()
		{
			var jamie = InitRider("jamie@cycletracker.com", "Bowen", "Jamie");
			var roubaix = InitBike("Specialized", "Roubaix");
			var trek = InitBike("Trek", "7500");
			var jamiesRoubaix = InitRiderBike(jamie, roubaix, "Black/Red", "SL2", 2013, 6092);
			var jamiesTrek = InitRiderBike(jamie, trek, "Black/Silver", "", 2011, 6327);

			InitJamiesRoubaixParts(jamiesRoubaix);
			InitJamiesTrekParts(jamiesTrek);

			var jeff = InitRider("jeff@cycletracker.com", "Beck", "Jeff");
			var stumpJumper = InitBike("Specialized", "Stumpjumper FSR Evo");
			var jeffsStumpJumper = InitRiderBike(jeff, stumpJumper, "Black/Yellow", "Comp 650b", 2015);

			InitJeffsStumpJumperParts(jeffsStumpJumper);
		}

	    private static void InitJeffsStumpJumperParts(RiderBike jeffsStumpJumper)
	    {
		    var frontHub = InitPart(PartType.FrontHub, "Hope", "Pro4", "Blue", 199.90M);
		    var rearHub = InitPart(PartType.RearHub, "Hope", "Pro4", "Blue", 199.90M);

		    InitBikePart(jeffsStumpJumper, frontHub, DateTime.UtcNow, 3, 180.00M, "Chain Reaction Cycles");
		    InitBikePart(jeffsStumpJumper, rearHub, DateTime.UtcNow, 3, 180.00M, "Chain Reaction Cycles");
	    }

	    private static void InitJamiesTrekParts(RiderBike trek)
		{
			var stockChain = InitPart(PartType.Chain, "", "", "Stock chain");
			InitBikePart(trek, stockChain, new DateTime(2011, 6, 8), 0, 0, "", BikeArea.NotApplicable, new DateTime(2014, 9, 11), 4923);

			var kmcChain = InitPart(PartType.Chain, "KMC", "X9.99", "");
			InitBikePart(trek, kmcChain, new DateTime(2014, 9, 11), 4923, 0, "Amazon");

			var stockCassette = InitPart(PartType.Cassette, "", "", "Stock cassette");
			InitBikePart(trek, stockCassette, new DateTime(2011, 6, 8), 0, 0, "", BikeArea.NotApplicable, new DateTime(2014, 9, 27), 4963);

			var sramCassette = InitPart(PartType.Cassette, "Sram", "950", "11-26T");
			InitBikePart(trek, sramCassette, new DateTime(2014, 9, 27), 4963, 0, "Eddy's Bike Shop (Montrose)");

			var shimanoCrankset = InitPart(PartType.Crankset, "Shimano", "M431", "28/38/48t");
			InitBikePart(trek, shimanoCrankset, new DateTime(2011, 6, 8), 0, 0, "", BikeArea.NotApplicable, new DateTime(2014, 9, 27), 4963);

			var fsaCrankset = InitPart(PartType.Crankset, "FSA", "Gossamer", "Compact Crankset N-11 386EVO 34/50t 172.5 Black");
			InitBikePart(trek, fsaCrankset, new DateTime(2014, 9, 27), 4963, 0, "Eddy's Bike Shop (Montrose)");

			var stockBracket = InitPart(PartType.BottomBracket, "", "", "Stock bottom bracket");
			InitBikePart(trek, stockBracket, new DateTime(2011, 6, 8), 0, 0, "", BikeArea.NotApplicable, new DateTime(2014, 9, 27), 4963);

			var fsaBracket = InitPart(PartType.BottomBracket, "FSA", "MEGAEVO STEEL", "68MM");
			InitBikePart(trek, fsaBracket, new DateTime(2014, 9, 27), 4963, 0, "Eddy's Bike Shop (Montrose)");

			var bontragerTire = InitPart(PartType.Tire, "Bontrager", "Hard Case Plus Triple Flat Protection", "700x35c");
			InitBikePart(trek, bontragerTire, new DateTime(2011, 6, 8), 0, 0, "", BikeArea.Front, new DateTime(2016, 7, 3), 6034);
			InitBikePart(trek, bontragerTire, new DateTime(2011, 6, 8), 0, 0, "", BikeArea.Rear, new DateTime(2016, 7, 3), 6034);

			var armadilloTire = InitPart(PartType.Tire, "Specialized", "Armadillo Elite All Condition", "700x32c");
			InitBikePart(trek, armadilloTire, new DateTime(2016, 7, 3), 6034, 0, "Eddy's Bike Shop (Montrose)", BikeArea.Front);
			InitBikePart(trek, armadilloTire, new DateTime(2016, 7, 3), 6034, 0, "Eddy's Bike Shop (Montrose)", BikeArea.Rear);
		}

		private static void InitJamiesRoubaixParts(RiderBike roubaix)
		{
			var espoirSportTire = InitPart(PartType.Tire, "Specialized", "Espoir Sport", "Double BlackBelt, 60TPI, wire bead, 700x23c");
			InitBikePart(roubaix, espoirSportTire, new DateTime(2014, 3, 24), 0, 0, "", BikeArea.Front, new DateTime(2014, 8, 31), 1634);
			InitBikePart(roubaix, espoirSportTire, new DateTime(2014, 3, 24), 0, 0, "", BikeArea.Rear, new DateTime(2014, 8, 13), 1377);

			var gatorskinTire = InitPart(PartType.Tire, "Continental", "Gatorskin", "700x25c");
			InitBikePart(roubaix, gatorskinTire, new DateTime(2014, 8, 31), 1634, 0, "Eddy's Bike Shop (Stow)", BikeArea.Front, new DateTime(2016, 6, 17), 5104);
			InitBikePart(roubaix, gatorskinTire, new DateTime(2014, 8, 13), 1377, 0, "Eddy's Bike Shop (Montrose)", BikeArea.Rear, new DateTime(2016, 6, 17), 5104);

			var enduranceTire = InitPart(PartType.Tire, "Specialized", "Endurance Roubaix Pro", "700x23/25");
			InitBikePart(roubaix, enduranceTire, new DateTime(2016, 6, 17), 5104, 0, "Eddy's Bike Shop (Montrose)", BikeArea.Front);
			InitBikePart(roubaix, enduranceTire, new DateTime(2016, 6, 17), 5104, 0, "Eddy's Bike Shop (Montrose)", BikeArea.Rear);

			var kmcChain = InitPart(PartType.Chain, "KMC", "X9", "9-speed, nickel plate");
			InitBikePart(roubaix, kmcChain, new DateTime(2014, 3, 24), 0, 0, "", BikeArea.NotApplicable, new DateTime(2014, 8, 31), 1634);

			var hg73Chain = InitPart(PartType.Chain, "Shimano", "CN-HG73", "9-speed");
			InitBikePart(roubaix, hg73Chain, new DateTime(2014, 9, 2), 1634, 0, "Eddy's Bike Shop (Stow)", BikeArea.NotApplicable, new DateTime(2016, 7, 18), 5362);

			var hg53Chain = InitPart(PartType.Chain, "Shimano", "CN-HG53", "9-speed");
			InitBikePart(roubaix, hg53Chain, new DateTime(2016, 7, 18), 5362, 0, "Amazon", BikeArea.NotApplicable, new DateTime(2017, 1, 24), 6092);

			var hg93Chain = InitPart(PartType.Chain, "Shimano", "CN-HG93", "9-speed");
			InitBikePart(roubaix, hg93Chain, new DateTime(2017, 1, 24), 6092, 0, "Eddy's Bike Shop (Montrose)");
		}
		
		private static Rider InitRider(string email, string lastName, string firstName)
		{
			var repository = new RiderRepository();
			var rider = new Rider { Email = email, LastName = lastName, FirstName = firstName };
			repository.Add(rider);
			return rider;
		}

		private static Bike InitBike(string make, string model)
		{
			var repository = new BikeRepository();
			var bike = new Bike { Make = make, Model = model };
			repository.Add(bike);
			return bike;
		}

		private static RiderBike InitRiderBike(Rider rider, Bike bike, string colors, string trim, int year, int? mileage = null)
		{
			var repository = new RiderBikeRepository();
			var riderBike = new RiderBike
			{
				RiderId = rider.Id,
				BikeId = bike.Id,
				Colors = colors,
				Trim = trim,
				Year = year,
				Mileage = mileage
			};
			repository.Add(riderBike);
			return riderBike;
		}

		private static Part InitPart(PartType partType, string manufacturer, string model, string description, decimal price = 0)
		{
			var repository = new PartRepository();
			var part = new Part
			{
				PartType = partType,
				Description = description,
				Model = model,
				Manufacturer = manufacturer,
				Price = price
			};
			repository.Add(part);
			return part;
		}

		private static BikePart InitBikePart(RiderBike riderBike, Part part, DateTime installedDate, int installedMileage, decimal purchasePrice, string purchaseRetailer, BikeArea installedBikeArea = BikeArea.NotApplicable, DateTime? replacedDate = null, int? replacedMileage = null)
		{
			var repository = new BikePartRepository();
			var bikePart = new BikePart
			{
				RiderBikeId = riderBike.Id,
				PartId = part.Id,
				InstalledDate = installedDate,
				InstalledBikeMileage = installedMileage,
				ReplacedDate = replacedDate,
				ReplacedBikeMileage = replacedMileage,
				PurchasePrice = purchasePrice,
				PurchaseRetailer = purchaseRetailer,
				InstalledBikeArea = installedBikeArea
			};
			repository.Add(bikePart);
			return bikePart;
		}
	}
}
