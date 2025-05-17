using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using FluentValidation;
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
		private readonly IValidator<AnnouncementAddDTO> _validator;

		public AnnouncementController(IMapper mapper, IAnnouncementService announcementService,IValidator<AnnouncementAddDTO> validator)
		{
			_mapper = mapper;
			_announcementService = announcementService;
			_validator = validator;
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

		[HttpGet]
		public IActionResult AddAnnouncement()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddAnnouncement(AnnouncementAddDTO announcementAddDTO)
		{
			var result = _validator.Validate(announcementAddDTO);
			if (!result.IsValid)
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
				return View(announcementAddDTO);
			}
			announcementAddDTO.AnnouncementDate = Convert.ToDateTime(DateTime.Now);
			// Formdan gelen "AnnouncementAddDTO" tipindeki nesneye veri tabanındaki entity tipine dönüştürüyoruz öyle database'e kaydediyoruz
			_announcementService.Insert(_mapper.Map<Announcement>(announcementAddDTO)); 
			return RedirectToAction("Index","Announcement");
		}

		public IActionResult  DeleteAnnouncement(int id)
		{
			_announcementService.Delete(id);
			return RedirectToAction("Index", "Announcement");
		}

		[HttpGet]
		public IActionResult UpdateAnnouncement(int id)
		{   // id'ye göre veritabanındaki Announcement entitysini bulup DTO 'ya çevirio view'e öyle gönderiyoruz
			return View(_mapper.Map<AnnouncementUpdateDTO>(_announcementService.GetById(id))); 
		}
		[HttpPost]
		public IActionResult UpdateAnnouncement(AnnouncementUpdateDTO announcementUpdateDTO)
		{
			announcementUpdateDTO.AnnouncementDate = Convert.ToDateTime(DateTime.Now);
			_announcementService.Update(_mapper.Map<Announcement>(announcementUpdateDTO));
			return RedirectToAction("Index","Announcement");
		}

	}
}
