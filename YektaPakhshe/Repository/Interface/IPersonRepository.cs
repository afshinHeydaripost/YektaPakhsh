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
	public interface IPersonRepository
    {
		Task<List<PersonViewModel>> GetList(string userId,string text="");
		Task<List<OwnerShipTypeViewModel>> GetOwnerShipTypeList();
		Task<string> GetMaxCode(string userId);
	}
}
