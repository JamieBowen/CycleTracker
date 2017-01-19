using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CycleTracker.Data.Models
{
    public class Rider : CycleTrackerBase
	{
		public string Email { get; set; }
		public string LastName { get; set; }
		public string FirstName { get; set; }
    }
}
