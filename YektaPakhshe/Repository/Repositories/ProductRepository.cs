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

    public class ProductRepository : IProductRepository
    {

        private readonly YektaPakhshContext _Context;

        public ProductRepository(YektaPakhshContext Context)
        {
            _Context = Context;

        }

        public async Task<List<ProductViewModel>> GetList(string userId, string text = "")
        {
            var query = _Context.Products.Select(x => new ProductViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                Code = x.Code,
                ProductGroupTitle = x.ProductGroup.Title,
                ProductGroupCode = x.ProductGroup.Code,
                UnitCode=x.Unit.Code,
                UnitTitle=x.Unit.Title
            }).AsQueryable();
            if (!string.IsNullOrEmpty(text))
                query = query.Where(x => x.Code.Contains(text) || x.Title.Contains(text) || x.ProductGroupTitle.Contains(text) || x.ProductGroupCode.Contains(text)).AsQueryable();
            return await query.ToListAsync();
        }
    }
}

