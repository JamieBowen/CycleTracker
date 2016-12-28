using System.Collections.Generic;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using CycleTracker.Data.Models;
using CycleTracker.Data.Repositories.Base;

namespace CycleTracker.Data.Repositories
{
	public interface IPartRepository : IRepository<Part>
	{
	}

	public class PartRepository : CycleTrackerBaseRepository<Part>, IPartRepository
    {
	    public PartRepository() : base("Parts")
	    {}	
    }
}
