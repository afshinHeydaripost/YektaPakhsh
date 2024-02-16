using Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repository.Interface;

namespace Site.Areas.Admin.Pages
{
    [Authorize]
    public class ProductGroupModel : PageModel
    {
        private readonly IUserRepository _userRep;
        private readonly IProductGroupRepository _productGroupRep;
        public ProductGroupModel(IUserRepository userRep, IProductGroupRepository productGroupRep)
        {
            _userRep = userRep;
            _productGroupRep = productGroupRep;

        }
        public async Task<IActionResult> OnGet()
        {
            var check = await _userRep.UserIsAdmin(User.GetLogginedUserID());
            if (!check.isSuccess)
                return RedirectToPage("./AccessDenied");
            return Page();
        }
        public async Task<IActionResult> OnGetList(string text = "")
        {
            var list = await _productGroupRep.GetList(User.GetLogginedUserID(), text);
            return new JsonResult(list);
        }
    }
}
