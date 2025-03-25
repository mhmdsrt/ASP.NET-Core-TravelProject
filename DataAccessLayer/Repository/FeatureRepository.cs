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
	public class FeatureRepository : GenericRepository<Feature>, IFeatureRepository
	{
		private readonly Context _context;
		public FeatureRepository(Context context) : base(context)
		{

		}
	}
}
