using DAL.Base;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interface;
using Helper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class GeneralRepository<T> : IGeneralRepository<T> where T : BaseEntity
    {
        private readonly YektaPakhshContext _Context;
        private readonly DbSet<T> entities;

        public GeneralRepository(YektaPakhshContext Context)
        {
            _Context = Context;
            entities = _Context.Set<T>();
        }

        public async Task<GeneralResponse> Add(T item)
        {
            var res = new GeneralResponse();

            try
            {
                entities.Add(item);
                await Save();
                res.isSuccess = true;
                res.Message = Message.SubmitSuccess;
                return res;
            }
            catch (Exception e)
            {
                return GeneralResponse.Fail(e);
            }
        }

        public async Task<GeneralResponse> Edit(T item)
        {
            var res = new GeneralResponse();
            try
            {
                _Context.DetachLocal(item, item.Id);
                await Save();
                res.isSuccess = true;
                res.Message = Message.SubmitSuccess;
                return res;
            }
            catch (Exception e)
            {
                return GeneralResponse.Fail(e);
            }
        }

        public async Task<GeneralResponse> Delete(int id)
        {
            var res = new GeneralResponse();
            try
            {
                var item = await GetById(id);
                if (item == null)
                {
                    res.Message = Message.NotFound;
                    return res;
                }
                entities.Remove(item);
                await Save();
                res.isSuccess = true;
                res.Message = Message.SubmitSuccessDelete;
                return res;
            }
            catch (Exception e)
            {
                return GeneralResponse.Fail(e);
            }
        }

        public async Task<GeneralResponse> Delete(T entity)
        {
            var res = new GeneralResponse();
            try
            {
                entities.Remove(entity);
                await Save();
                res.isSuccess = true;
                res.Message = Message.SubmitSuccessDelete;
                return res;
            }
            catch (Exception e)
            {
                return GeneralResponse.Fail(e);
            }
        }

        public async Task<List<T>> GetAll()
        {
            return await entities.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await entities.SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task Save()
        {
            await _Context.SaveChangesAsync();
        }
    }
}
