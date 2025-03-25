using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class GenericService<T> : IGenericService<T> where T : class
	{
		/*
         "private readonly IGenericRepository<T> _repository;" ifadesinin private olma sebebi sadece sınıf içerisinde erişilebilir olmasını sağlamaktır.
          readonly sayesinden sadece ve sadece tanımlandığı anda veya constructor içerisinde değeri atanabilir ve sonra kesinlikle değiştirilemez.
         */

		private readonly IGenericRepository<T> _repository; // GenericRepository değilde IGenericRepository dememizin sebebi her repository'nin kendini özgü metotları olabileceğinden dolayı.

		public GenericService(IGenericRepository<T> repository) // repository, IGenericRepository<T> interface'ini T tipinde implement eden bir class'ın nesnesi oluyor.
		{
			_repository = repository; // Dependency injection yaparak hangi servis ile çalışacaksak o servisin constructor metodundan gelen repository'u alıyoruz.
		}
		
		public T GetById(int id)
		{
			return _repository.GetById(id);
		}
		public IEnumerable<T> GetAll()
		{
			return _repository.GetAll();
		}
		public void Insert(T entity)
		{
			_repository.Insert(entity);
		}

		public void Delete(int id)
		{
			_repository.Delete(id);
		}

		public void Update(T entity)
		{
			_repository.Update(entity);
			
		}

		

	}
}
