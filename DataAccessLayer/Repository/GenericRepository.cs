using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
	/*
	  Ctrl + Shift + Space => Metodun farklı overload'larını görebilmemizi sağlar.
	 */
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		private readonly Context _context;
		public GenericRepository(Context context)
		{
			_context = context;
		}
		public T GetById(int id)
		{
			return _context.Set<T>().Find(id);
		}

		public IEnumerable<T> GetAll()
		{
			return _context.Set<T>().ToList();
		}

		public void Insert(T entity)
		{
			_context.Set<T>().Add(entity);
			_context.SaveChanges();
		}

		public void Delete(int id)
		{
			var entity = _context.Set<T>().Find(id);
			_context.Remove(entity);
			_context.SaveChanges();
		}

		public void Update(T entity)
		{
			_context.Update(entity);
			_context.SaveChanges();
		}
	}
}
