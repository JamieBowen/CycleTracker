using System.IO;
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
				CreateDatabase(connection);
			}

			return connection;
		}

		private static void CreateDatabase(SqliteConnection connection)
		{
			connection.Open();
			connection.Execute(
				@"create table Bikes
                (
					Id                  INTEGER primary key,
                    Make                TEXT not null,
                    Model               TEXT not null,
                    Year                INTEGER not null,
					Trim	            TEXT null,
					Colors     	        TEXT null
                )"
			);
		}
	}
}
