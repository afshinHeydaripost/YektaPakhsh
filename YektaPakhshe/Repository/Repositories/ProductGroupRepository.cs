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

    public class ProductGroupRepository : IProductGroupRepository
    {

        private readonly YektaPakhshContext _Context;

        public ProductGroupRepository(YektaPakhshContext Context)
        {
            _Context = Context;

        }

        public async Task<List<ProductGroupViewModel>> GetList(string userId, string text = "")
        {
            return await  _Context.ProductGroups.Select(x => new ProductGroupViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                ParentTitle = (x.ParentId == null) ? "" : _Context.ProductGroups.FirstOrDefault(z => z.Id == x.ParentId).Title,
                ParentCode = (x.ParentId == null) ? "" : _Context.ProductGroups.FirstOrDefault(z => z.Id == x.ParentId).Code,
                Code = x.Code,
            }).ToListAsync();
            //if (!string.IsNullOrEmpty(text))
            //    query = query.Where(x => x.Code.Contains(text) || x.Title.Contains(text)).AsQueryable();
            //return await query.ToListAsync();
        }
    }
}

