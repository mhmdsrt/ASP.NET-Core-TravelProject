using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	// Rolleme işlemi için kullancağımız sınıf

	/*
	 Kullanıcı Rollerini özelleştirmek için oluşturduğumuz AppRole classıdır burası.
	 Normalden IdentityRole classı ID değerini string tipinde tutar biz int tipinde tutmak istediğimiz için <int> yaptık.
	 Yani Varsayılan olarak Identity Primary Key 'ler için string tipini kullanır biz int kullanmak istediğimiz için <int> verdik.
	 Identity kütüphanesinin verdiği "IdentityRole" classından hariç kendimiz eksta sütünlar kullanmak istiyorsak veya özelleştirmek
	 istiyorsak böyle kullanıyoruz.

	 */
	public class AppRole : IdentityRole<int>
	{
	}
}
