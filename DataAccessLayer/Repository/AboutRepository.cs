using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
	public class AboutRepository : GenericRepository<About>, IAboutRepository
	{
		private readonly Context _context;
		public AboutRepository(Context context) : base(context)
		{

		}
	}
}
