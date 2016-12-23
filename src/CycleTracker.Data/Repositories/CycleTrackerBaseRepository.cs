using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using CycleTracker.Data.Models;
using CycleTracker.Data.Repositories.Base;
using Dapper;

namespace CycleTracker.Data.Repositories
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
				cn.Execute(updateQuery, parameters);
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
			var result = Helpers.DynamicQuery.GetDynamicQuery(_tableName, predicate);

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
	}
}
