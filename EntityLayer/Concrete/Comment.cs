using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Comment
	{
		public int CommentID { get; set; }
		public string CommentUser { get; set; }
		public DateTime CommentDate { get; set; }
		public string CommentContent { get; set; }
		public bool CommentStatus { get; set; }
		public int DestinationID { get; set; }
		public Destination Destination { get; set; }
	}


	/*
	 Navigation Property özelliği için  " public Destination Destination { get; set; }" ifadesi kullanılması yeterlidir.
	 Navigation Property sayesinden bir Comment nesnesinin ait olduğu DestinationID 'sine eşit olan Destination nesnesinin propertylerine ulaşabiliyoruz.

	 Burada "public Destination Destination { get; set; }" ile Gidilecek Yer ile Yorum arasında ilişki kurarken Virtual kullansaydık
	 Lazy Loading'i açmış olurduk. Dolayısıyla İlişkili Veriye erişilmek istenildiği zaman çekilirdi. 
	

	Daha sonrasında Linq sorgularu ile Include() Metodu ile ilişkileri verileri en başta yükleyip sonra çekme yöntemi olan
	Eager Loading yöntemini kullanıcaz. Çok sayıda kayıt varsa daha performanslıdır.

	Özet:
	Lazy Loading'de veriye erişilmek istenildiği zaman çekiliyordu ya bunun için her defasında veri tabanına sorgu dönüyor. Dolayısıyla
	foreach() gibi sürekli veri erişimde Lazy Loading her defasından veriye erişmek için sorgu döndürdüğünden dolayı performans düşer.
	n+1 performans problemine yol açabilir.

	Eager Loading ise tüm ilişkileri verileri en başta çekiyor. Tek sorgu ile işimize yarasada yaramasada tüm verileri getiriyoruz veri tabanına
	sadece 1 sorgu ile iletişim kurmamız yetiyor ama gereksiz verileri getirme ihtimalimizde oluyor ona dikkat etmemiz lazım.
	Sorunlardan bazıları iç içe ilişkili verileri çekerken kullandığımız ThenInclude() metodu ile SQL karmaşıklaşıp VeriTabanını yavaşlatabilir.


	 */
}
