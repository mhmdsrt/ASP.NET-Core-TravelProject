using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.ContactUsDTOs;
using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using TravelProject.Models;

namespace TravelProject.Controllers
{
	[AllowAnonymous]
	public class ContactUsController : Controller
	{
		private readonly IMapper _mapper;
		private readonly IContactUsService _contactUsService;

		public ContactUsController(IMapper mapper, IContactUsService contactUsService)
		{
			_mapper = mapper;
			_contactUsService = contactUsService;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(ContactUsAddDTO contactUsAddDTO)
		{
			contactUsAddDTO.ContactUsMessageDate = Convert.ToDateTime(DateTime.Now);
			contactUsAddDTO.ContactUsStatus = true;
			_contactUsService.Insert(_mapper.Map<ContactUs>(contactUsAddDTO));
			return View();
		}

	}
}
