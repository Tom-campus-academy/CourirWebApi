namespace Courir.IDataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Courir.Entities;

    public interface IBaseDataAccess<T> : IDisposable
            where T : IBaseEntity
    {
        Task<int> Count();

        Task<T> Create(T itemToCreate);

        Task Delete(params object[] keyValues);

        Task<T> Find(params object[] keyValues);

        Task<List<T>> List();

        Task<List<T>> ListOrderByDate();

        Task<List<T>> ListSkipTake(int skip, int take);

        Task<List<T>> ListSkipTakeOrderByDate(int skip, int take);

        Task<T> Update(T itemToUpdate, params object[] keyValues);
    }
}