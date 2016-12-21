using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Dapper;

namespace CycleTracker.Data.Repositories
{
    public class BikeRepository : SqLiteBaseRepository
    {
	    public void getAll()
	    {
		    if (!File.Exists(DbFileLocation))
		    {
			    CreateDatabase();
		    }
	    }

	    private static void CreateDatabase()
	    {
		    using (var cnn = CycleTrackerDbConnection())
		    {
			    cnn.Open();
			    cnn.Execute(
					@"create table Bikes
                    (
						Id                  UNIQUEIDENTIFIER primary key,
                        Make                varchar(100) not null,
                        Model               varchar(100) not null,
                        Year                int not null,
						Trim	            varchar(100) null,
						ColorDescription	varchar(200) null
                      )");
		    }
	    }
    }
}
