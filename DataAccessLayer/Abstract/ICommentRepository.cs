using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	public interface ICommentRepository : IGenericRepository<Comment>
	{
		IQueryable<Comment> GetAllCommentByDestinationId(int id);
		IQueryable<Comment> GetAllCommentIncludeDestination(); // Tüm Yorumları ilişkili olduğu Destination nesnesi ile beraber getir
		 int GetCommentCountByDestinationId(int id);
	}
}
