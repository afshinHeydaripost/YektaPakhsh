using Helper;
using Repository.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Admin;

namespace Repository.Interface
{
	public interface IUserRepository
	{
		Task<UserViewModel> GetCurrent(ClaimsPrincipal user);
		Task<string> GetUserId(ClaimsPrincipal user);
		Task<GeneralResponse> UpdateUserInfo(UserViewModel user);
	}
}
