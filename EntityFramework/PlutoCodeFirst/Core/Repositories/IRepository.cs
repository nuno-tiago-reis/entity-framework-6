using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PlutoCodeFirst.Core.Repositories
{
	public interface IRepository<TEntity> where TEntity : class
	{
		/// <summary>
		/// Gets an entity with the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		TEntity Get(int id);

		/// <summary>
		/// Gets an entity using the specified predicate.
		/// </summary>
		/// <param name="predicate">The predicate.</param>
		/// <returns></returns>
		TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

		/// <summary>
		/// Gets all the entities.
		/// </summary>
		IEnumerable<TEntity> GetAll();

		/// <summary>
		/// Finds the entities using specified predicate.
		/// </summary>
		/// <param name="predicate">The predicate.</param>
		IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

		/// <summary>
		/// Adds the specified entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		void Add(TEntity entity);

		/// <summary>
		/// Adds the specified range.
		/// </summary>
		/// <param name="entities">The entities.</param>
		void AddRange(IEnumerable<TEntity> entities);

		/// <summary>
		/// Removes the specified entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		void Remove(TEntity entity);

		/// <summary>
		/// Removes the specified range.
		/// </summary>
		/// <param name="entities">The entities.</param>
		void RemoveRange(IEnumerable<TEntity> entities);
	}
}