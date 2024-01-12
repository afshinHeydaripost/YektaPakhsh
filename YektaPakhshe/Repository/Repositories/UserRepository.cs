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

namespace Repository.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly YektaPakhshContext _Context;
		private readonly UserManager<ApplicationUser> _userManager;
		public UserRepository(YektaPakhshContext Context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
		{
			_Context = Context;
			_userManager = userManager;
			_signInManager = signInManager;
		}

		public async Task<UserViewModel> GetById(string userId)
		{
			return await _Context.AspNetUsers.Where(x => x.Id == userId).Select(x => new UserViewModel()
			{
				Address = x.Address,
				firstName = x.Address,
				LastName = x.LastName,
				NationalCode = x.NationalCode,
				ProfilePicture = x.ProfilePicture,
				strBirthday = x.Birthday.ToPersianDate()
			}).FirstOrDefaultAsync();
		}

		public async Task<UserViewModel> GetCurrent(ClaimsPrincipal user)
		{

			var currentUser = await _userManager.GetUserAsync(user);
			return new UserViewModel()
			{
				Address = currentUser.Address,
				firstName = currentUser.firstName,
				LastName = currentUser.LastName,
				NationalCode = currentUser.NationalCode,
				UserId = currentUser.Id,
				PhoneNumber = currentUser.PhoneNumber,
				Email = currentUser.Email,
				ProfilePicture = currentUser.ProfilePicture,
				strBirthday = currentUser.Birthday.ToPersianDate()
			};
		}

		public async Task<string> GetUserId(ClaimsPrincipal user)
		{
			var currentUser = await _userManager.GetUserAsync(user);
			return currentUser.Id;
		}

		public async Task<GeneralResponse> UpdateUserInfo(UserViewModel user)
		{
			try
			{
				var User = await _userManager.FindByIdAsync(user.UserId);
				User.PhoneNumber = user.PhoneNumber;
				User.Email = user.Email;
				User.LastName = user.LastName;
				User.firstName = user.firstName;
				User.NationalCode = user.NationalCode;
				User.Address = user.Address;
				User.ProfilePicture = user.ProfilePicture;
				User.Birthday = user.strBirthday.ToDateTime();
				var res=await  _userManager.UpdateAsync(User);
				if (!res.Succeeded) {
					var errList = new List<string>();
					foreach (var error in res.Errors)
					{
						errList.Add(error.Description);
					}
					return Helper.GeneralResponse.Fail(string.Join("<br />", errList));
				}
				return GeneralResponse.Success();
			}
			catch (Exception e) {
				return GeneralResponse.Fail(e);
			}
		}
	}
}
