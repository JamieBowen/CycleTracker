using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace CycleTracker.Data.Repositories
{
    public abstract class SqLiteBaseRepository
    {
	    public static string DbFileLocation => Directory.GetCurrentDirectory() + "CycleTrackerData.sqlite";

	    public static SqliteConnection CycleTrackerDbConnection()
	    {
			return new SqliteConnection("Data Source=" + DbFileLocation);
	    }
    }
}
