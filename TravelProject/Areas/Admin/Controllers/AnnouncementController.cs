using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.AnnouncementDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelProject.Areas.Admin.Controllers
{
	[Area("Admin")]
	[AllowAnonymous]
	[Route("Admin/[Controller]/[Action]/{id?}")]
	public class AnnouncementController : Controller
	{
		/*
		Automapper tüm dönüşüm işlemlerini IMapper interface'i üzerinden yapar.
		Map<T>() metodu da bu interface'in içindedir.
		 */
		private readonly IMapper _mapper;
		private readonly IAnnouncementService _announcementService;

		public AnnouncementController(IMapper mapper, IAnnouncementService announcementService)
		{
			_mapper = mapper;
			_announcementService = announcementService;
		}
		public IActionResult Index()
		{
			/*
			 _mapper.Map<<Destination>>(Source) -> Paranten içindeki kaynağı <> içerisinde hedefe dönüştürür
			 _mapper.Map<IEnumerable<AnnouncementListDTO>>(_announcementService.GetAll()) ifadesi açıklama:
			 (_announcementService.GetAll()) -> Nereden? , Dönüşüm yapacağımız Kaynak
			 <IEnumerable<AnnouncementListDTO>> -> Nereye ? , Dönüşüm yapacağımız Hedef
			 */


			return View(_mapper.Map<IEnumerable<AnnouncementListDTO>>(_announcementService.GetAll()));
		}
	}
}
