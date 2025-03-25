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
	public class SubAboutService : GenericService<SubAbout>, ISubAboutService
	{
		private readonly ISubAboutRepository _subAboutRepository;

		public SubAboutService(ISubAboutRepository subAboutRepository) : base(subAboutRepository)
		{
			_subAboutRepository = subAboutRepository;
		}
	}
}
