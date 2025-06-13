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
		private readonly IAppUserService _appUserService;
		private readonly UserManager<AppUser> _userManager;

		public RoleController(RoleManager<AppRole> roleManager, IMapper mapper, IAppRoleService appRoleService, IAppUserService appUserService, UserManager<AppUser> userManager)
		{
			_roleManager = roleManager;
			_mapper = mapper;
			_appRoleService = appRoleService;
			_appUserService = appUserService;
			_userManager = userManager;
		}

		public async Task<IActionResult> Index()
		{
			return View(await _appRoleService.GetAllRole());
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

		[HttpGet]
		public async Task<IActionResult> AssignRole(int id)// Assign -> Atamak
		{
			var user = await _appUserService.GetUserById(id); // parametredeki id ye göre kullanıcı al
			TempData["UserId"] = id;
			var roles = await _appRoleService.GetAllRole(); // Sistem tanım tüm rolleri getirir. AspNetRoles tablosu.
			var userRoles = await _userManager.GetRolesAsync(user); // kullanıcının sahip olduğu tüm rollerini getir. List<String> listesidir
			// kullanıcının hangi rolleri oldugun öprenip almak için:
			List<AppRoleAssignRoleDTO> appRoleAssignRoleDTOList = new List<AppRoleAssignRoleDTO>();
			foreach (var item in roles)
			{
				AppRoleAssignRoleDTO appRoleAssignRoleDTO = new AppRoleAssignRoleDTO();
				appRoleAssignRoleDTO.RoleId = item.Id;
				appRoleAssignRoleDTO.RoleName = item.Name;
				appRoleAssignRoleDTO.RoleExist = userRoles.Contains(item.Name); // kullanıcının rollerinde, genel rol listesinde o rol varsa RoleExist true olucak
				appRoleAssignRoleDTOList.Add(appRoleAssignRoleDTO);
			}
			return View(appRoleAssignRoleDTOList);
		}

		[HttpPost]
		public async Task<IActionResult> AssignRole(List<AppRoleAssignRoleDTO> appRoleAssignRoleDTOs)
		{
			var userId = (int)TempData["UserId"];
			var user = await _appUserService.GetUserById(userId);
			// Formdan Exits true(işaretli kutucuklar) dönen rol adlarını rol olarak ekle, false dönen (işaretlenmemiş kutucuklar)
			// rolleri ise kullanıcıdan kaldır
			foreach (var item in appRoleAssignRoleDTOs)
			{
				if (item.RoleExist)
				{
					await _userManager.AddToRoleAsync(user, item.RoleName);
				}

				else
				{
					await _userManager.RemoveFromRoleAsync(user, item.RoleName);
				}
			}
			return RedirectToAction("Index", "User", new { area = "Admin" });
		}
	}
}
