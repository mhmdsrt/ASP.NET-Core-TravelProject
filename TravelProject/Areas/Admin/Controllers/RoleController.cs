using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.AppRoleDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TravelProject.Areas.Admin.Controllers
{
	[Area("Admin")]
	[AllowAnonymous]
	[Route("Admin/[Controller]/[Action]/{id?}")]
	public class RoleController : Controller
	{
		private readonly RoleManager<AppRole> _roleManager;
		private readonly IMapper _mapper;
		private readonly IAppRoleService _appRoleService;

		public RoleController(RoleManager<AppRole> roleManager, IMapper mapper, IAppRoleService appRoleService)
		{
			_roleManager = roleManager;
			_mapper = mapper;
			_appRoleService = appRoleService;
		}

		public IActionResult Index()
		{
			return View(_roleManager.Roles.ToList());
		}

		[HttpGet]
		public IActionResult CreateRole()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateRole(AppRoleCreateDTO appRoleCreateDTO)
		{
			await _roleManager.CreateAsync(_mapper.Map<AppRole>(appRoleCreateDTO));
			return RedirectToAction("Index", "Role", new { area = "Admin" });
		}

		public async Task<IActionResult> DeleteRole(int id)
		{
			await _appRoleService.RemoveAppRole(id);
			return RedirectToAction("Index", "Role", new { area = "Admin" });
		}

		[HttpGet]
		public async Task<IActionResult> UpdateRole(int id)
		{
			
			return View(_mapper.Map<AppRoleUpdateDTO>(await _appRoleService.GetRoleById(id)));
		}

		[HttpPost]
		public async Task<IActionResult> UpdateRole(AppRoleUpdateDTO appRoleUpdateDTO)
		{
			await _appRoleService.UpdateRole(_mapper.Map<AppRole>(appRoleUpdateDTO));
			return RedirectToAction("Index", "Role", new { area = "Admin" });
		}
	}
}
