using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using CycleTracker.Data.Models;
using Dapper;

namespace CycleTracker.Data.Repositories.Base
{
	public interface IRepository<T>
	{
		long Add(T item);
		void Remove(long id);
		void Update(T item);
		T FindById(long id);
		IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
		IEnumerable<T> FindAll();
	}

	public abstract class CycleTrackerBaseRepository<T> : SqLiteBaseRepository, IRepository<T> where T : CycleTrackerBase
	{
		private readonly string _tableName;
		
	    public CycleTrackerBaseRepository(string tableName)
	    {
		    _tableName = tableName;
		}

		internal virtual dynamic Mapping(T item)
		{
			return item;
		}

		public virtual long Add(T item)
		{
			using (IDbConnection cn = CycleTrackerDbConnection())
			{
				var parameters = (object)Mapping(item);
				cn.Open();
				var insertQuery = Helpers.DynamicQuery.GetInsertQuery(_tableName, parameters);
				return (long)cn.ExecuteScalar(insertQuery, parameters);
			}
		}

		public virtual void Update(T item)
		{
			using (IDbConnection cn = CycleTrackerDbConnection())
			{
				var parameters = (object)Mapping(item);
				cn.Open();
				var updateQuery = Helpers.DynamicQuery.GetUpdateQuery(_tableName, parameters);
				cn.Execute(updateQuery);
			}
		}

		public virtual void Remove(long id)
		{
			using (IDbConnection cn = CycleTrackerDbConnection())
			{
				cn.Open();
				cn.Execute("DELETE FROM " + _tableName + " WHERE Id=@Id", new { Id = id });
			}
		}

		public virtual T FindById(long id)
		{
			T item = default(T);

			using (IDbConnection cn = CycleTrackerDbConnection())
			{
				cn.Open();
				item = cn.Query<T>("SELECT * FROM " + _tableName + " WHERE Id=@Id", new { Id = id }).SingleOrDefault();
			}

			return item;
		}

		public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
		{
			IEnumerable<T> items = null;

			// extract the dynamic sql query and parameters from predicate
			Helpers.QueryResult result = Helpers.DynamicQuery.GetDynamicQuery(_tableName, predicate);

			using (IDbConnection cn = CycleTrackerDbConnection())
			{
				cn.Open();
				items = cn.Query<T>(result.Sql, (object)result.Param);
			}

			return items;
		}

		public virtual IEnumerable<T> FindAll()
		{
			IEnumerable<T> items = null;

			using (IDbConnection cn = CycleTrackerDbConnection())
			{
				cn.Open();
				items = cn.Query<T>("SELECT * FROM " + _tableName);
			}

			return items;
		}

		/// <summary>
		/// Used to pull single child object and its parent.
		/// </summary>
		/// <typeparam name="T2"></typeparam>
		/// <param name="query"></param>
		/// <param name="idParam"></param>
		/// <returns></returns>
		internal virtual T FindIncluding<T2>(string query, long idParam)
		{
			return FindAllIncludingInternal<T2>(query, idParam).FirstOrDefault();
		}

		/// <summary>
		/// User to pull a single child object and its parent.
		/// </summary>
		/// <typeparam name="T2"></typeparam>
		/// <param name="query"></param>
		/// <returns></returns>
		internal virtual IEnumerable<T> FindAllIncluding<T2>(string query)
		{
			return FindAllIncludingInternal<T2>(query, null);
		}

		private IEnumerable<T> FindAllIncludingInternal<T2>(string query, long? idParam)
		{
			object param = null;
			if (idParam.HasValue)
			{
				param = new { Id = idParam };
			}
			
			var lookup = new Dictionary<long, T>();
			IEnumerable<T> returnList = new List<T>();
			
			using (IDbConnection cn = CycleTrackerDbConnection())
			{
				cn.Open();

				returnList = cn.Query<T, T2, T>(query, (T baseObj, T2 inclusionObj) =>
				{
					T obj;

					if (!lookup.TryGetValue(baseObj.Id, out obj))
					{
						lookup.Add(baseObj.Id, obj = baseObj);
					}

					var props = obj.GetType().GetProperties();

					var prop = props.FirstOrDefault(p => p.PropertyType == typeof(T2));

					if (prop == null)
					{
						throw new Exception("There is no property of (T2) on the base return type.");
					}

					prop.SetValue(obj, inclusionObj);

					return obj;
				},
					param).AsEnumerable();
			}

			return returnList;
		}

		/// <summary>
		/// Used to pull a collection of children and its parent.
		/// </summary>
		/// <typeparam name="T2"></typeparam>
		/// <param name="query"></param>
		/// <param name="idParam"></param>
		/// <returns></returns>
		internal virtual T FindIncludingList<T2>(string query, long idParam)
		{
			return FindAllIncludingListInternal<T2>(query, idParam).FirstOrDefault();
		}

		/// <summary>
		/// Used to pull a collection of children and its parent.
		/// </summary>
		/// <typeparam name="T2"></typeparam>
		/// <param name="query"></param>
		/// <returns></returns>
		internal virtual IEnumerable<T> FindAllIncludingList<T2>(string query)
		{
			return FindAllIncludingListInternal<T2>(query, null);
		}

		private IEnumerable<T> FindAllIncludingListInternal<T2>(string query, long? idParam)
		{
			object param = null;
			if (idParam.HasValue)
			{
				param = new { Id = idParam };
			}


			var lookup = new Dictionary<long, T>();
			IEnumerable<T> returnList = new List<T>();



			using (IDbConnection cn = CycleTrackerDbConnection())
			{
				cn.Open();

				returnList = cn.Query<T, T2, T>(query, (T baseObj, T2 inclusionObj) =>
				{
					T obj;

					if (!lookup.TryGetValue(baseObj.Id, out obj))
					{
						lookup.Add(baseObj.Id, obj = baseObj);
					}

					var props = obj.GetType().GetProperties();

					var prop = props.FirstOrDefault(p => p.PropertyType == typeof(List<T2>));

					if (prop == null)
					{
						throw new Exception("There is no property of (List<T2>) on the base return type.");
					}

					var childList = prop.GetValue(obj) as List<T2> ?? new List<T2>();

					childList.Add(inclusionObj);

					prop.SetValue(obj, childList);

					return obj;
				},
					param).AsEnumerable();
			}

			return returnList;
		}
	}
}
