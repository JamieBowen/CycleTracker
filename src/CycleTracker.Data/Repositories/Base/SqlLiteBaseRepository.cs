﻿using System.IO;
using Dapper;
using Microsoft.Data.Sqlite;

namespace CycleTracker.Data.Repositories.Base
{
	public abstract class SqLiteBaseRepository
	{
		public static string DbFileDirectory => Directory.GetCurrentDirectory() + "/Data/";

		public static string DbFileLocation => DbFileDirectory + "CycleTrackerData.sqlite";

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
			Directory.CreateDirectory(DbFileDirectory);
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

			connection.Execute(
				@"create table Parts
                (
					Id                   INTEGER primary key,
                    Name                 TEXT not null,
                    Description          TEXT null,
                    InstalledDate        TEXT not null,
					InstalledBikeMileage INTEGER not null,
					ReplacedDate         TEXT null,
					ReplacedBikeMileage  INTEGER null,
					AccruedMileage       INTEGER null,
					Retailer			 TEXT null,
					BikeId				 INTEGER not null
                )"
			);
		}
	}
}