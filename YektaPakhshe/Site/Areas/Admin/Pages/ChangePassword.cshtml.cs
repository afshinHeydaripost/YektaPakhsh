using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Identity;
using System.Net;
using ViewModels.Admin;

namespace Site.Areas.Admin.Pages
{
	[Authorize]
	public class ChangePasswordModel : PageModel
	{
		private readonly UserManager<ApplicationUser> _userManager;


		public ChangePasswordModel(
			UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
		}
		[BindProperty]
		public ChangePasswordViewModel Input { get; set; }

		public void OnGet()
		{
		}
		public async Task<IActionResult> OnPostChange()
		{
			if (!ModelState.IsValid)
			{
				return new JsonResult(Helper.GeneralResponse.Fail("اطلاعات ارسالی معتبر نیست"));
			}
			var user = await _userManager.GetUserAsync(User);
			if (user == null)
				return new JsonResult(Helper.GeneralResponse.NotFound());

			var changePasswordResult = await _userManager.ChangePasswordAsync(user, Input.OldPassword, Input.NewPassword);
			if (!changePasswordResult.Succeeded)
			{
				var errList = new List<string>();
				foreach (var error in changePasswordResult.Errors)
				{
					errList.Add(error.Description);
				}
				return new JsonResult(Helper.GeneralResponse.Fail(string.Join("<br />", errList)));
			}
			return new JsonResult(Helper.GeneralResponse.Success());
		}
	}
}
