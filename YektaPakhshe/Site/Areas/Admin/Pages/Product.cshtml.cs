using Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repository.Interface;

namespace Site.Areas.Admin.Pages
{
	[Authorize]
	public class ProductModel : PageModel
	{



		private readonly IUserRepository _userRep;
		public ProductModel(IUserRepository userRep)
		{
			_userRep = userRep;
		}
		public async Task<IActionResult> OnGet()
		{
			var check = await _userRep.UserIsAdmin(User.GetLogginedUserID());
			if (!check.isSuccess)
				return RedirectToPage("./AccessDenied");
			return Page();
		}
	}
}
