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
    public class Feature2Repository:GenericRepository<Feature2>,IFeature2Repository
    {
		private readonly Context _context;
		public Feature2Repository(Context context) : base(context)
		{
			_context = context;
		}
	}
}
