using DAL.Models;
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
	public interface IPersonRepository : IGeneralRepository<Person>
    {
		Task<List<PersonViewModel>> GetList(string userId,string text="");
		Task<List<OwnerShipTypeViewModel>> GetOwnerShipTypeList();
		Task<Person> GetPerson(int id,string userId);
		Task<string> GetMaxCode(string userId);
		Task<GeneralResponse> CheckCodeTitle(string userId,int ownerShipTypeId, string code,string title,int? id);
	}
}
