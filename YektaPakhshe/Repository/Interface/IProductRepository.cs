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
	public interface IProductRepository
	{
		Task<List<ProductViewModel>> GetList(string userId,string text="");
	}
}
