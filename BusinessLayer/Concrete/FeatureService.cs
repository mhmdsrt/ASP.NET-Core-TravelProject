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
	public class FeatureService : GenericService<Feature>, IFeatureService
	{
		private readonly IFeatureRepository _featureRepository;
		public FeatureService(IFeatureRepository featureRepository) : base(featureRepository)
		{
			_featureRepository = featureRepository;
		}
	}
}
