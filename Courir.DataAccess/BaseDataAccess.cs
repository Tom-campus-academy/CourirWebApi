namespace Courir.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Courir.Entities;
    using Courir.IDataAccess;

    using Microsoft.EntityFrameworkCore;

    public class BaseDataAccess<T> : IBaseDataAccess<T>
        where T : class, IBaseEntity
    {
        public BaseDataAccess(CourirContext context)
        {
            this.Context = context;
        }

        public CourirContext Context { get; private set; }

        public async Task<int> Count()
        {
            return await this.Context.Set<T>().CountAsync();
        }

        public async Task<T> Create(T itemToCreate)
        {
            itemToCreate.CreatedDate = DateTime.Now;
            itemToCreate.UpdatedDate = null;
            await this.Context.Set<T>().AddAsync(itemToCreate);
            await this.Context.SaveChangesAsync();

            return itemToCreate;
        }

        public async Task Delete(params object[] keyValues)
        {
            T item = await this.Context.Set<T>().FindAsync(keyValues);
            if (item != null)
            {
                this.Context.Set<T>().Remove(item);
                await this.Context.SaveChangesAsync();
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<T> Find(params object[] keyValues)
        {
            return await this.Context.Set<T>().FindAsync(keyValues);
        }

        public async Task<List<T>> List()
        {
            return await this.Context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> ListOrderByDate()
        {
            return await this.Context.Set<T>().OrderByDescending(obj => obj.UpdatedDate).ThenByDescending(obj => obj.CreatedDate).ToListAsync();
        }

        public async Task<List<T>> ListSkipTake(int skip, int take)
        {
            return await this.Context.Set<T>().Skip(skip).Take(take).ToListAsync();
        }

        public async Task<List<T>> ListSkipTakeOrderByDate(int skip, int take)
        {
            return await this.Context.Set<T>().Skip(skip).Take(take).OrderByDescending(obj => obj.UpdatedDate).ThenByDescending(obj => obj.CreatedDate).ToListAsync();
        }

        public async Task<T> Update(T itemToUpdate, params object[] keyValues)
        {
            T item = await this.Context.Set<T>().FindAsync(keyValues);
            itemToUpdate.CreatedDate = item.CreatedDate;
            itemToUpdate.UpdatedDate = DateTime.Now;
            this.Context.Entry(item).CurrentValues.SetValues(itemToUpdate);
            await this.Context.SaveChangesAsync();

            return itemToUpdate;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Context?.Dispose();
            }
        }
    }
}