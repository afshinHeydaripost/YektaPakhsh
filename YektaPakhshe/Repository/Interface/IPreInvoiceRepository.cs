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
    public interface IPreInvoiceRepository : IGeneralRepository<PreInvoice>
    {
        Task<List<PreInvoiceViewModel>> GetList(string userId, string text = "");
        Task<string> GetMaxNo(string userId);
    }
}
