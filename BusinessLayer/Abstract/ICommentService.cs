using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface ICommentService : IGenericService<Comment>
	{
		IEnumerable<Comment> GetAllCommentByDestinationId(int id);
		IEnumerable<Comment> GetAllCommentIncludeDestination(); // Tüm Yorumları ilişkili olduğu Destination nesnesi ile beraber getir

	}
}
