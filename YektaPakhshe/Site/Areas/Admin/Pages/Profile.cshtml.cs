using Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Identity;
using Repository.Interface;
using System.Net;
using ViewModels.Admin;

namespace Site.Areas.Admin.Pages
{
	[Authorize]
	public class ProfileModel : PageModel
	{
		private readonly UserManager<ApplicationUser> _userManager;


		private readonly IUserRepository _userRep;
		public ProfileModel(IUserRepository userRep)
		{
			_userRep = userRep;
		}
		[BindProperty]
		public UserViewModel user { get; set; }

		
		public async Task OnGet()
		{
			user =await  _userRep.GetCurrent(User);
		}
		public async Task<IActionResult> OnPostChange()
		{
			//if (!ModelState.IsValid)
			//{
			//	return new JsonResult(Helper.GeneralResponse.Fail("اطلاعات ارسالی معتبر نیست"));
			//}
			user.UserId = User.GetLogginedUserID();
			return new JsonResult(await _userRep.UpdateUserInfo(user));
		}
	}
}
