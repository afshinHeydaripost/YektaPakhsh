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

    public class PreInvoiceRepository : GeneralRepository<PreInvoice>, IPreInvoiceRepository
    {

        private readonly YektaPakhshContext _Context;
        private readonly IUserRepository _userRepository;


        public PreInvoiceRepository(YektaPakhshContext Context, IUserRepository userRepository) : base(Context)
        {
            _Context = Context;
            _userRepository = userRepository;
        }

        public Task<List<PreInvoiceViewModel>> GetList(string userId, string text = "")
        {
            throw new NotImplementedException();
        }

        public Task<string> GetMaxNo(string userId)
        {
            throw new NotImplementedException();
        }
    }
}

