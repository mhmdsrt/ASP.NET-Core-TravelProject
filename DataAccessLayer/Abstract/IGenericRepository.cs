using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{


	/*
	 ✅ Evet, Repository veya Service katmanında IQueryable<T> döndürüp, UI veya Controller katmanında IEnumerable<T> olarak 
	 kullanmak en doğrusudur.
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
/*
		Eğer sadece okuma işlemi yapılacaksa IEnumerable<T>, ICollection<T> ' e göre daha hızlıdır ve daha az bellek tüketir.
		IEnumerable<T> sadece okuma işlemlerinde kullanılır.
		ICollection<T> ise tüm CRUD işlemlerinde kullanılabilir.
		Ve biz burada GetAll ile sadece listeleme(okuma) yapacağımızdan dolayı List<T> ve ICollection<T> tiplerine göre
		daha az bellek tüketir ve daha hızlıdır(performanslıdır).
		IEnumerable<T>, en hızlı Lazy Loading sağlar.
		*/


/*
 | Özellik / Tip                     | `List<T>`                    | `IEnumerable<T>`              | `IQueryable<T>`             | `ICollection<T>`         | `IReadOnlyCollection<T>`   |
| --------------------------------- | ---------------------------- | ----------------------------- | --------------------------- | ------------------------ | -------------------------- |
| 🔍 **Veri Kaynağı**               | Bellekte (RAM)               | Genelde bellekte              | Veritabanı gibi dış kaynak  | Bellekte                 | Bellekte                   |
| ⚙️ **Filtreleme Nerede Yapılır?** | RAM                          | RAM                           | SQL (veritabanında)         | RAM                      | RAM                        |
| 📦 **Somut Veri mi?**             | ✅ Evet                       | ❌ Hayır                       | ❌ Hayır                     | ✅ Evet (çoğunlukla) | ✅ Evet                     |
| 🔄 **Değiştirilebilir mi?**       | ✅ Evet (Add, Remove vs)      | ❌ Hayır                       | ❌ Hayır                     | ✅ Evet              | ❌ Hayır                    |
| 📈 **Performans (Büyük veri)**    | Orta                         | Düşük (tüm veri RAM'e gelir)  | ✅ Yüksek (SQL’e çevrilir)   | Orta                    | Orta                       |
| 🧠 **LINQ destekler mi?**         | ✅ Evet                       | ✅ Evet                        | ✅ Evet (veritabanına uygun) | ❌ (sadece temel)    | ❌ (sadece temel)           |
| 🧩 **Kapsadığı Interface**        | `ICollection`, `IEnumerable` | `IEnumerable`                 | `IQueryable`, `IEnumerable` | `IEnumerable`            | `IEnumerable`              |
| 🔒 **Immutable (salt okunur)?**   | ❌ Hayır                      | ✅ Evet (değiştiremezsin)      | ✅ Evet (değiştiremezsin)    | ❌ Hayır             | ✅ Evet                     |
| 🧰 **Tipik Kullanım Alanı**       | Servislerde sonuç döndürme   | Genel veri dolaşımı           | Veritabanı sorguları (EF)   | Navigation property’ler  | Readonly liste ihtiyaçları |
| 🧪 **Yaygın Kullanım Örneği**     | `ToList()` dönüşü            | `foreach`, `First()`, `Any()` | `.Where().Select()`         | `entity.RelatedEntities` | `GetAll().AsReadOnly()`    |

 */


/*
 Sadece okuma gerekiyorsa → IEnumerable<T>

Değiştirme gerekiyorsa → ICollection<T> veya List<T>

Veritabanına sorgu atılacaksa → IQueryable<T>
 */






/*
 
 * 🔹 1. List<T>
En temel somut (somutlanmış) koleksiyondur.

RAM'de veri tutar.

İçine eleman eklenebilir, silinebilir, sayısı alınabilir.

LINQ sorgularını destekler.

🔸 Ne zaman kullanılır?

Bellekte veriyle işlem yapılacaksa.

Tüm veriler hemen çekilip kullanılacaksa.


 2. IEnumerable<T>
Sadece veri üzerinde dolaşmaya izin verir.

Okuma (Read-Only) amaçlıdır.

foreach, First(), Where() gibi LINQ komutlarıyla çalışır.

Lazy/deferred execution sağlar: Yani sorgu, çağrılana kadar çalışmaz.

🔸 Ne zaman kullanılır?

Filtreleme ya da döngü için sadece okumak gerekiyorsa.

Hafif veri erişimi gerekiyorsa.


 3. IQueryable<T>
IEnumerable<T>’in gelişmiş halidir.

IQueryable<T> ile yazılan LINQ sorguları veritabanına SQL sorgusu olarak çevrilir.

Böylece filtreleme/sıralama gibi işlemler veritabanında çalışır -> çok daha performanslı olur.

🔸 Ne zaman kullanılır?

Entity Framework ile veritabanı sorgularında.

Daha az veri çekmek istiyorsan.


 4. ICollection<T>
IEnumerable’in üstüdür.

Add, Remove, Count gibi işlemleri destekler.

EF Core’da navigation property'lerde kullanılır.

🔸 Ne zaman kullanılır?

EF ile entity’ler arası ilişkiyi temsil ederken.

Değiştirilebilir koleksiyon gerekiyorsa.

 */


/*
		| İhtiyacın                                                    | Kullanılacak Tip                | Açıklama                                        |
| ------------------------------------------------------------ | ------------------------------- | ----------------------------------------------- |
| 🔄 Listeyi güncellemek istiyorum                             | `List<T>` veya `ICollection<T>` | Eleman ekle/çıkar yapacaksan uygundur           |
| 📊 SQL’de filtreleme yaparak veritabanından çekmek istiyorum | `IQueryable<T>`                 | EF Core gibi ORM'lerde performans için en iyisi |
| 🧭 Yalnızca veriyi döndürmek, dolaşmak istiyorum             | `IEnumerable<T>`                | Basit dolaşım (readonly)                        |
| 🔐 Salt okunur bir liste döndürmek istiyorum                 | `IReadOnlyCollection<T>`        | Public API'lerde güvenli koleksiyon döndürme    |
| 🧷 Navigation property kullanıyorum                          | `ICollection<T>`                | EF navigation property'lerde önerilen tip       |
	 
	 */

/*
 ✅ IQueryable<T> Ne Yapar?
LINQ sorgularını veritabanına SQL olarak çevirir.

EF Core gibi ORM araçları IQueryable nesnesini okuyarak tek bir SQL sorgusu oluşturur.

Bu sorgu veritabanında çalışır → veriler sadece ihtiyaç kadar çekilir.

❓ Peki SQL’e çevrilmeseydi, sorgular nerede çalışırdı?
Bellekte (RAM’de) çalışırdı.

Yani veri:

Önce tamamen veritabanından çekilir,

Sonra LINQ sorgusu .NET içinde çalışır (CLR belleğinde).


 */