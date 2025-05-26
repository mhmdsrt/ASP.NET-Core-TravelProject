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
	public class About2Service : GenericService<About2>, IAbout2Service
	{
		private readonly IAbout2Repository _about2Repository;

		public About2Service(IAbout2Repository about2Repository) : base(about2Repository)
		{
			_about2Repository = about2Repository;
		}
	}
}
