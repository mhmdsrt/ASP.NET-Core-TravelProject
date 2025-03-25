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
	public class GuideService : GenericService<Guide>, IGuideService
	{
		private readonly IGuideRepository _guideRepository;
		public GuideService(IGuideRepository guideRepository) : base(guideRepository)
		{
			_guideRepository = guideRepository;
		}
	}
}
