namespace Courir.IBusiness
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Courir.BusinessObject;

    public interface IStockBusiness : IDisposable
    {
        Task<KeyValuePair<bool, Stock>> Create(Stock itemToCreate);

        Task<KeyValuePair<bool, Stock>> Delete(int id);

        Task<Stock> Get(int id);

        Task<List<Stock>> List();

        Task<KeyValuePair<bool, Stock>> Update(int id, Stock itemToUpdate);
    }
}