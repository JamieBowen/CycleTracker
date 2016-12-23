using System;
using System.Net.Sockets;
using CycleTracker.Data.Models.EnumTypes;

namespace CycleTracker.Data.Models
{
    public class Part : CycleTrackerBase
    {
	    public string Manufacture { get; set; }
	    public string Model { get; set; }
	    public string Description { get; set; }
	    public decimal Price { get; set; }
	    public string UpcCode { get; set; }
	    public DateTime InstalledDate { get; set; }
	    public int InstalledBikeMileage { get; set; }
	    public DateTime ReplacedDate { get; set; }
	    public int ReplacedBikeMileage { get; set; }
	    public int AccruedMileage { get; set; }
	    public string Retailer { get; set; }
	    public PartType PartType { get; set; }
		public long BikeId { get; set; }
    }
}
