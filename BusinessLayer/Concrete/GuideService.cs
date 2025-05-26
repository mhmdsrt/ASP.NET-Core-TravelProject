using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
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

		public void ChangeToFalse(int id)
		{
			_guideRepository.ChangeToFalse(id);
		}

		public void ChangeToTrue(int id)
		{
			_guideRepository.ChangeToTrue(id);
		}
		public int GetGuideCount()
		{
			return _guideRepository.GetGuideCount();
		}


	}
}
