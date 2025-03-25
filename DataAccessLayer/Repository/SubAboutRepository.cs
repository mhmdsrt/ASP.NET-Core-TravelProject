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
	public class SubAboutRepository : GenericRepository<SubAbout>, ISubAboutRepository
	{
		private readonly Context _context;
		public SubAboutRepository(Context context) : base(context)
		{

		}
	}
}
