using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository.Identity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Admin;
using Helper;
using System.Security.Claims;
using Repository.Context;

namespace Repository.Repositories
{

    public class PersonRepository : GeneralRepository<Person>, IPersonRepository
    {

        private readonly YektaPakhshContext _Context;
        private readonly IUserRepository _userRepository;


        public PersonRepository(YektaPakhshContext Context, IUserRepository userRepository) : base(Context)
        {
            _Context = Context;
            _userRepository = userRepository;
        }

        public async Task<GeneralResponse> CheckCodeTitle(string userId, int ownerShipTypeId, string code, string title, int? id)
        {
            var query = _Context.Person.Where(x => x.Code == code).AsQueryable();
            var msg = "کد";
            if (ownerShipTypeId == 2)
            {
                query = query.Where(x => x.Title == title).AsQueryable();
                msg = msg + " و عنوان";
            }
            if (id != null && id > 0)
            {
                query = query.Where(x => x.Id != id).AsQueryable();
            }
            if (await query.AnyAsync())
                return GeneralResponse.Success($"{msg} تکراری است");
            return GeneralResponse.Fail();
        }

        public async Task<List<PersonViewModel>> GetList(string userId, string text = "")
        {
            var query = _Context.Person.Select(x => new PersonViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                Code = x.Code,
                UserId = x.UserId,
                OwnerShipTypeTitle = x.OwnerShipType.Title,
                UserTitle = x.User.FirstName + " " + x.User.LastName
            }).AsQueryable();
            var UserIsAdmin = await _userRepository.UserIsAdmin(userId);
            if (!UserIsAdmin.isSuccess)
                query = query.Where(x => x.UserId == userId).AsQueryable();
            if (!string.IsNullOrEmpty(text))
                query = query.Where(x => x.Code.Contains(text) || x.Title.Contains(text)).AsQueryable();
            return await query.ToListAsync();
        }

        public async Task<string> GetMaxCode(string userId)
        {
            int code = 1;
            if (await _Context.Person.AnyAsync())
            {
                code = int.Parse(await _Context.Person.MaxAsync(x => x.Code));
                code = code + 1;
            }
            return code.ToString().PadLeft(6, '0');
        }

        public async Task<List<OwnerShipTypeViewModel>> GetOwnerShipTypeList()
        {
            return await _Context.OwnerShipType.Select(x => new OwnerShipTypeViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                Code = x.Code,
            }).ToListAsync();
        }

        public async Task<PersonItemViewModel> GetPerson(int id, string userId)
        {
            var user = await _userRepository.UserIsAdmin(userId);
            var person = await GetById(id);
            var item = new PersonItemViewModel()
            {
                Code = person.Code,
                Id = person.Id,
                BirthDate = person.BirthDate,
                Description = person.Description,
                Disabled = person.Disabled,
                EconomicCode = person.EconomicCode,
                FirstName = person.FirstName,
                LastName = person.LastName,
                NationalityCode = person.NationalityCode,
                OwnerShipTypeId = person.OwnerShipTypeId,
                Taxable = person.Taxable,
                Reference = person.Reference,
                RegisterationCode = person.RegisterationCode,
                Title = person.Title
            };
            if (user.isSuccess)
                return item;
            if (person.UserId == userId)
                return item;
            return null;
        }
    }
}

