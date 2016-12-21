using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CycleTracker.Data.Models
{
    public class Part
    {
	    public Guid Id { get; set; }
	    public string Name { get; set; }
	    public string Description { get; set; }
	    public DateTimeOffset InstallationDate { get; set; }
	    public int InstallationBikeMilage { get; set; }
	    public DateTimeOffset ReplacedDate { get; set; }
	    public int ReplacedBikeMilage { get; set; }
	    public int AccurredMilage { get; set; }
	    public string Retailer { get; set; }
    }
}
