using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class CommentService : GenericService<Comment>, ICommentService
	{
		private readonly ICommentRepository _commentRepository;

		public CommentService(ICommentRepository commentRepository) : base(commentRepository)
		{
			_commentRepository = commentRepository;
		}
		public IEnumerable<Comment> GetAllCommentByDestinationId(int id)
		{
			return _commentRepository.GetAllCommentByDestinationId(id);
		}

		public IEnumerable<Comment> GetAllCommentIncludeDestination()// Tüm Yorumları ilişkili olduğu Destination nesnesi ile beraber getir
		{
			return _commentRepository.GetAllCommentIncludeDestination();
		}

	}
}
