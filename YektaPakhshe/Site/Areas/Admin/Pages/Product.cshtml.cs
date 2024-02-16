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
        private readonly IProductRepository _productRep;
        public ProductModel(IUserRepository userRep, IProductRepository productRep)
        {
            _userRep = userRep;
            _productRep = productRep;

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
            var list = await _productRep.GetList(User.GetLogginedUserID(), text);
            return new JsonResult(list);
        }
    }
}
