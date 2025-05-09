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
    public class GuideRepository:GenericRepository<Guide>,IGuideRepository
    {
		private readonly Context _context;
		public GuideRepository(Context context) : base(context)
		{
			_context = context;
		}

		public void ChangeToFalse(int id)
		{
			var entityGuide = _context.Guides.Find(id);
			entityGuide.GuideStatus = false;
			_context.Update(entityGuide);
			_context.SaveChanges();
		}

		public void ChangeToTrue(int id)
		{
			var entityGuide = _context.Guides.Find(id);
			entityGuide.GuideStatus = true;
			_context.Update(entityGuide);
			_context.SaveChanges();

		}

	}
}
