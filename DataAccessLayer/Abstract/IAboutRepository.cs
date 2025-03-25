using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	/*
	IAboutRepository interface'ini miras alıcak sınıflar hem IAboutRepository interface'indeki metotları
	hemde IGenericRepository interface'indeki metotları <About> tipinde implement etmek zorundadır.

	Çünkü IAboutRepository İnterface'i IGenericRepository interface'inden miras almıştır.
	*/
	public interface IAboutRepository : IGenericRepository<About>
	{
	}
}
