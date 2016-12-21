using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CycleTracker.Data.Models;
using Dapper;

namespace CycleTracker.Data.Repositories
{
	public interface IRepository<T>
	{
		int Add(T item);
		void Remove(T item);
		void Update(T item);
		T FindById(int id);
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

		public virtual int Add(T item)
		{
			int id;

			using (IDbConnection cn = CycleTrackerDbConnection())
			{
				var parameters = (object)Mapping(item);
				cn.Open();
				var insertQuery = Helpers.DynamicQuery.GetInsertQuery(_tableName, parameters);
				int.TryParse(cn.ExecuteScalar(insertQuery, parameters).ToString(), out id);
			}

			return id;
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

		public virtual void Remove(T item)
		{
			using (IDbConnection cn = CycleTrackerDbConnection())
			{
				cn.Open();
				cn.Execute("DELETE FROM " + _tableName + " WHERE Id=@Id", new { Id = item.Id });
			}
		}

		public virtual T FindById(int id)
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
	}
}
