namespace TravelProject.Areas.Member.Models
{
	public class UserProfileEditViewModel
	{
		public string Name { get; set; }
		public string SurName { get; set; }
		public string Mail { get; set; }
		public string Password { get; set; }
		public string ConfirmPassword { get; set; }
		public string PhoneNumber { get; set; }
		public string ImageUrl { get; set; }
		public IFormFile ImageFile { get; set; }
	}
}
