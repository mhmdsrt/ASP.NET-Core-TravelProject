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
	public class ContactService : GenericService<Contact>, IContactService
	{
		private readonly IContactRepository _contactRepository;
		public ContactService(IContactRepository contactRepository) : base(contactRepository)
		{
			_contactRepository = contactRepository;
		}
	}
}
