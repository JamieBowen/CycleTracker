using CycleTracker.Data.Models;

namespace CycleTracker.TestApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
			var repo = new Data.Repositories.BikeRepository();
			var bike = new Bike { Make = "fuck you", Model = "no. fuck you.", Colors = "black", Trim = "fu", Year = 2016};

			bike.Id = repo.Add(bike);

	        var huh = repo.FindById(bike.Id);

	        var x = 1;
        }
    }
}
