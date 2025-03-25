using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	/*
		Eğer sadece okuma işlemi yapılacaksa IEnumerable<T>, ICollection<T> ' e göre daha hızlıdır ve daha az bellek tüketir.
		IEnumerable<T> sadece okuma işlemlerinde kullanılır.
		ICollection<T> ise tüm CRUD işlemlerinde kullanılabilir.
		Ve biz burada GetAll ile sadece listeleme(okuma) yapacağımızdan dolayı List<T> ve ICollection<T> tiplerine göre
		daha az bellek tüketir ve daha hızlıdır(performanslıdır).
		IEnumerable<T>, en hızlı Lazy Loading sağlar.
		*/
	public interface IGenericRepository<T> where T : class
	{
		T GetById(int id);
		IEnumerable<T> GetAll();
		void Delete(int id);
		void Insert(T entity);
		void Update(T entity);
	}
}
