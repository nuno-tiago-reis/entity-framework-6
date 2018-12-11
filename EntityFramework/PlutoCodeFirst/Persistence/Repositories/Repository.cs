using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

using PlutoCodeFirst.Core.Repositories;

namespace PlutoCodeFirst.Model.Repositories
{
	public class Repository<TEntity, TDbContext> : IRepository<TEntity>
		where TEntity : class
		where TDbContext : DbContext
	{
		/// <summary>
		/// The context.
		/// </summary>
		protected readonly TDbContext Context;

		/// <summary>
		/// Initializes a new instance of the <see cref="Repository{TEntity, TDbContext}"/> class.
		/// </summary>
		/// <param name="context">The context.</param>
		public Repository(TDbContext context)
		{
			this.Context = context;
		}

		/// <inheritdoc />
		public TEntity Get(int id)
		{
			// Here we are working with a DbContext, not PlutoContext. So we don't have DbSets 
			// such as Courses or Authors, and we need to use the generic Set() method to access them.
			return this.Context.Set<TEntity>().Find(id);
		}

		/// <inheritdoc />
		public IEnumerable<TEntity> GetAll()
		{
			// Note that here I've repeated Context.Set<TEntity>() in every method and this is causing
			// too much noise. I could get a reference to the DbSet returned from this method in the 
			// constructor and store it in a private field like _entities. This way, the implementation
			// of our methods would be cleaner:
			// 
			// _entities.ToList();
			// _entities.Where();
			// _entities.SingleOrDefault();
			// 
			// I didn't change it because I wanted the code to look like the videos. But feel free to change
			// this on your own.
			return this.Context.Set<TEntity>().ToList();
		}

		/// <inheritdoc />
		public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
		{
			return this.Context.Set<TEntity>().Where(predicate);
		}

		/// <inheritdoc />
		public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
		{
			return this.Context.Set<TEntity>().SingleOrDefault(predicate);
		}

		/// <inheritdoc />
		public void Add(TEntity entity)
		{
			this.Context.Set<TEntity>().Add(entity);
		}

		/// <inheritdoc />
		public void AddRange(IEnumerable<TEntity> entities)
		{
			this.Context.Set<TEntity>().AddRange(entities);
		}

		/// <inheritdoc />
		public void Remove(TEntity entity)
		{
			this.Context.Set<TEntity>().Remove(entity);
		}

		/// <inheritdoc />
		public void RemoveRange(IEnumerable<TEntity> entities)
		{
			this.Context.Set<TEntity>().RemoveRange(entities);
		}
	}
}