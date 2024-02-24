using DAL.Models;
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
    public class PreInvoiceAddOrEditModel : PageModel
    {
        private readonly IUserRepository _userRep;
        private readonly IPreInvoiceRepository _reInvoiceRep;

        private readonly IPersonRepository _personRep;
        public PreInvoiceAddOrEditModel(IPersonRepository personRep, IUserRepository userRep, IPreInvoiceRepository reInvoiceRep)
        {
            _personRep = personRep;
            _userRep = userRep;
            _reInvoiceRep = reInvoiceRep;

        }

        [BindProperty]
        public PreInvoiceViewModel preInvoice { get; set; }
        public List<PersonViewModel> Persons { get; set; }
        public async Task<IActionResult> OnGet(int? id)
        {
            Persons = await _personRep.GetList(User.GetLogginedUserID());
            if (id is null)
            {
                preInvoice = new PreInvoiceViewModel()
                {
                    PreInvoiceNo = await _reInvoiceRep.GetMaxNo(),
                };
            }
            else
            {
                //preInvoice = await _reInvoiceRep.GetPreInvoiceById(id ?? 0, User.GetLogginedUserID());
            }
            return Page();
        }
        public async Task<IActionResult> OnGetMaxNo()
        {
            return new JsonResult(await _reInvoiceRep.GetMaxNo());
        }
    }
}
