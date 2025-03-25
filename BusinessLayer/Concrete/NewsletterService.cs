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
	public class NewsletterService : GenericService<Newsletter>, INewsletterService
	{
		private readonly INewsletterRepository _newsletterRepository;

		public NewsletterService(INewsletterRepository newsletterRepository) : base(newsletterRepository)
		{
			_newsletterRepository = newsletterRepository;
		}
	}
}
