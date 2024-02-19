using Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repository.Interface;
using ViewModels.Admin;

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
        public List<OwnerShipTypeViewModel> ownerShipType { get; set; }
        [BindProperty]
        public PersonItemViewModel Person { get; set; }
        public async Task<IActionResult> OnGet()
        {
            ownerShipType = await _personRep.GetOwnerShipTypeList();
            return Page();
        }
        public async Task<IActionResult> OnGetMaxCode()
        {
            var code = await _personRep.GetMaxCode(User.GetLogginedUserID());
            return new JsonResult(code);
        }
        public async Task<IActionResult> OnGetList(string text = "")
        {
            var list = await _personRep.GetList(User.GetLogginedUserID(), text);
            return new JsonResult(list);
        }
        public async Task<IActionResult> OnPostAddOrEdit()
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(Helper.GeneralResponse.Fail("اطلاعات ارسالی معتبر نیست"));
            }
            return new JsonResult(Helper.GeneralResponse.Success());
        }
    }
}
