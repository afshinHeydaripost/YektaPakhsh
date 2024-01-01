using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Identity;
using ViewModels.Admin;

namespace Site.Areas.Admin.Pages
{
	public class ChangePasswordModel : PageModel
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;


		public ChangePasswordModel(
			UserManager<ApplicationUser> userManager,
			SignInManager<ApplicationUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;

		}
		[BindProperty]
		public ChangePasswordViewModel Input { get; set; }

		public void OnGet()
		{
		}
		public async Task<IActionResult> OnPostChangePassword(ChangePasswordViewModel Input)
		{
			if (!ModelState.IsValid)
			{
				return new JsonResult(Helper.GeneralResponse.Fail("اطلاعات ارسالی معتبر نیست"));
			}
			return new JsonResult(Helper.GeneralResponse.Fail("اطلاعات ارسالی معتبر نیست"));
		}
	}
}
