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
        public async Task<IActionResult> OnGetById(int id)
        {
            var person = await _personRep.GetPerson(id, User.GetLogginedUserID());
            return new JsonResult(person);
        }
        public async Task<IActionResult> OnPostAdd()
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(Helper.GeneralResponse.Fail("اطلاعات ارسالی معتبر نیست"));
            }
            var check = await _personRep.CheckCodeTitle(User.GetLogginedUserID(), Person.OwnerShipTypeId, Person.Code, Person.Title, Person.Id);
            if (check.isSuccess)
            {
                check.isSuccess = false;
                return new JsonResult(check);
            }
            var person = new Person()
            {
                Code = Person.Code,
                FirstName = Person.FirstName,
                LastName = Person.LastName,
                Title = (Person.OwnerShipTypeId == 1) ? Person.FirstName + " " + Person.LastName : Person.Title,
                OwnerShipTypeId = Person.OwnerShipTypeId,
                EconomicCode = Person.EconomicCode,
                NationalityCode = Person.NationalityCode,
                CreateDateTime = DateTime.Now,
                BirthDate = Person.BirthDate.PersianToEnglish(),
                Description = Person.Description,
                Reference = Person.Reference,
                Taxable = Person.Taxable,
                RegisterationCode = Person.RegisterationCode,
                UserId = User.GetLogginedUserID()
            };
            return new JsonResult(await _personRep.Add(person));
        }

        public async Task<IActionResult> OnPostEdit()
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(Helper.GeneralResponse.Fail("اطلاعات ارسالی معتبر نیست"));
            }
            var person = await _personRep.GetPerson(Person.Id??0, User.GetLogginedUserID());
            if (person == null)
                return new JsonResult(Helper.GeneralResponse.NotFound());
            var check = await _personRep.CheckCodeTitle(User.GetLogginedUserID(), Person.OwnerShipTypeId, Person.Code, Person.Title, Person.Id);
            if (check.isSuccess)
            {
                check.isSuccess = false;
                return new JsonResult(check);
            }


            person.Code = Person.Code;
            person.FirstName = Person.FirstName;
            person.LastName = Person.LastName;
            person.Title = (Person.OwnerShipTypeId == 1) ? Person.FirstName + " " + Person.LastName : Person.Title;
            person.OwnerShipTypeId = Person.OwnerShipTypeId;
            person.EconomicCode = Person.EconomicCode;
            person.NationalityCode = Person.NationalityCode;
            person.BirthDate = Person.BirthDate.PersianToEnglish();
            person.Description = Person.Description;
            person.Reference = Person.Reference;
            person.Taxable = Person.Taxable;
            person.RegisterationCode = Person.RegisterationCode;
            return new JsonResult(await _personRep.Add(person));
        }
    }
}
