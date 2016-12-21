using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using CycleTracker.Data.Models;
using Dapper;

namespace CycleTracker.Data.Repositories
{
    public class BikeRepository : Repositories.CycleTrackerBaseRepository<Bike>
    {
	    public BikeRepository() : base("Bikes")
	    {
	    }
    }
}
