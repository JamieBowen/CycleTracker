using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CycleTracker.TestApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
			var repo = new Data.Repositories.BikeRepository();

			repo.getAll();
        }
    }
}
