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

        public async Task<GeneralResponse> GetCheckNo(string no, int? id)
        {
            var query = _Context.PreInvoices.Where(x => x.PreInvoiceNo == int.Parse(no)).AsQueryable();
            if (id is not null)
            {
                query = query.Where(x => x.Id != id).AsQueryable();
            }
            if (await query.AnyAsync())
                return GeneralResponse.Fail("شماره پیش فاکتور است");
            return GeneralResponse.Success();
        }

        public async Task<List<PreInvoiceViewModel>> GetList(string userId, string text = "")
        {
            var query = _Context.PreInvoices.AsQueryable();
            var UserIsAdmin = await _userRepository.UserIsAdmin(userId);
            if (!UserIsAdmin.isSuccess)
                query = query.Where(x => x.UserId == userId).AsQueryable();
            if (!string.IsNullOrEmpty(text))
                query = query.Where(x => x.strPreInvoiceNo.Contains(text)).AsQueryable();
            return await query.Select(x => new PreInvoiceViewModel()
            {
                PreInvoiceNo = x.strPreInvoiceNo,
                PreInvoiceDate = DateTools.ToPersianDate(x.PreInvoiceDate),
                Reference = x.Reference,
                DiscountPrice = x.strDiscountPrice,
                Code = x.Person.Code,
                TaxPrice = x.strTaxPrice,
                DiscountRate = x.DiscountRate,
                Id = x.Id,
                Revoked = x.Revoked,
                Title = x.Person.Title,
                TotalNetPrice = x.strTotalNetPrice,
            }).ToListAsync();
        }



        public async Task<string> GetMaxNo()
        {
            var no = 0;
            if (await _Context.PreInvoices.AnyAsync())
                no = await _Context.PreInvoices.MaxAsync(x => x.PreInvoiceNo);
            return (no + 1).ToString().PadLeft(10, '0');
        }
    }
}

