using Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repository.Interface;

namespace Site.Areas.Admin.Pages
{
    [Authorize]
    public class PreInvoiceModel : PageModel
    {
        private readonly IUserRepository _userRep;
        private readonly IPreInvoiceRepository _reInvoiceRep;
        public PreInvoiceModel(IUserRepository userRep, IPreInvoiceRepository reInvoiceRep)
        {
            _userRep = userRep;
            _reInvoiceRep = reInvoiceRep;

        }
        public async Task<IActionResult> OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnGetList(string text = "")
        {
            var list = await _reInvoiceRep.GetList(User.GetLogginedUserID(), text);
            return new JsonResult(list);
        }
    }
}
