using System;

namespace CycleTracker.Data.Models
{
    public class Part : CycleTrackerBase
    {
	    public string Name { get; set; }
	    public string Description { get; set; }
	    public DateTimeOffset InstalledDate { get; set; }
	    public int InstalledBikeMileage { get; set; }
	    public DateTimeOffset ReplacedDate { get; set; }
	    public int ReplacedBikeMileage { get; set; }
	    public int AccruedMileage { get; set; }
	    public string Retailer { get; set; }
    }
}
