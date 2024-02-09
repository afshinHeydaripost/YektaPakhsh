using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
	public static class IdentityTools
	{
		public static string GetLogginedUserID(this ClaimsPrincipal user)
		{
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}
			var claim = user.FindFirst(ClaimTypes.NameIdentifier);
			return claim.Value;
		}
	}
}
