using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.Sqlite;

namespace CycleTracker.Data.Repositories
{
    public abstract class SqLiteBaseRepository
    {
	    public static string DbFileLocation => Directory.GetCurrentDirectory() + "CycleTrackerData.sqlite";

	    public static SqliteConnection CycleTrackerDbConnection()
	    {
		    var connection = new SqliteConnection("Data Source=" + DbFileLocation);

			if (!File.Exists(DbFileLocation))
			{
				CreateDatabase();
			}

		    return connection;
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
						Colors     	        varchar(200) null
                      )");
			}
		}
	}
}
