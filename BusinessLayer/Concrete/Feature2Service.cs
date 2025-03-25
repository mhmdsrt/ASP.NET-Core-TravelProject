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
    public class Feature2Service:GenericService<Feature2>,IFeature2Service
    {
		private readonly IFeature2Repository _feature2Repository;
		public Feature2Service(IFeature2Repository feature2Repository) : base(feature2Repository)
		{
			_feature2Repository = feature2Repository;
		}
	}
}
