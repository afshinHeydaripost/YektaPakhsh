using Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repository.Interface;

namespace Site.Areas.Admin.Pages
{
    [Authorize]
    public class PersonModel : PageModel
    {

        private readonly IPersonRepository _personRep;
        public PersonModel(IPersonRepository personRep)
        {
            _personRep = personRep;
        }
        public async Task<IActionResult> OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnGetList(string text = "")
        {
            var list = await _personRep.GetList(User.GetLogginedUserID(), text);
            return new JsonResult(list);
        }
    }
}
