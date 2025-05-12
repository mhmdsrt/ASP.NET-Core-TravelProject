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
	public class ContactUsService : GenericService<ContactUs>, IContactUsService
	{
		private readonly IContactUsRepository _contactUsRepository;

		public ContactUsService(IContactUsRepository contactUsRepository) : base(contactUsRepository)
		{
			_contactUsRepository = contactUsRepository;
		}
	}
}
