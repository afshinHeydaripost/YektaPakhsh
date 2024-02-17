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

    public class PersonRepository : IPersonRepository
    {

        private readonly YektaPakhshContext _Context;
        private readonly IUserRepository _userRepository;


        public PersonRepository(YektaPakhshContext Context, IUserRepository userRepository)
        {
            _Context = Context;
            _userRepository = userRepository;
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
    }
}

