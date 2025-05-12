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
	public class AnnouncementService:GenericService<Announcement>,IAnnouncementService
	{
		private readonly IAnnouncementRepository _announcementRepository;
		public AnnouncementService(IAnnouncementRepository announcementRepository):base(announcementRepository)
		{
			_announcementRepository = announcementRepository;
		}
	}
}
