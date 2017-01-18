using System;
using System.Net.Sockets;
using CycleTracker.Data.Models.EnumTypes;

namespace CycleTracker.Data.Models
{
    public class Part : CycleTrackerBase
    {
	    public string Manufacturer { get; set; }
	    public string Model { get; set; }
	    public string Description { get; set; }
	    public decimal Price { get; set; }
	    public string UpcCode { get; set; }
	    public PartType PartType { get; set; }
    }
}
