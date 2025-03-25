using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IGenericService<T> where T : class
	{
		T GetById(int id);
		IEnumerable<T> GetAll();
		void Delete(int id);
		void Insert(T entity);
		void Update(T entity);
	}
}
