using System;

namespace CycleTracker.Data.Models
{
    public class Part
    {
	    public Guid Id { get; set; }
	    public string Name { get; set; }
	    public string Description { get; set; }
	    public DateTimeOffset InstallationDate { get; set; }
	    public int InstallationBikeMileage { get; set; }
	    public DateTimeOffset ReplacedDate { get; set; }
	    public int ReplacedBikeMileage { get; set; }
	    public int AccruedMileage { get; set; }
	    public string Retailer { get; set; }
    }
}
