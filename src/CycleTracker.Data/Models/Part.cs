using System;
using System.Net.Sockets;

namespace CycleTracker.Data.Models
{
    public class Part : CycleTrackerBase
    {
	    public string Name { get; set; }
	    public string Description { get; set; }
	    public DateTime InstalledDate { get; set; }
	    public int InstalledBikeMileage { get; set; }
	    public DateTime ReplacedDate { get; set; }
	    public int ReplacedBikeMileage { get; set; }
	    public int AccruedMileage { get; set; }
	    public string Retailer { get; set; }
		public long BikeId { get; set; }
    }
}
