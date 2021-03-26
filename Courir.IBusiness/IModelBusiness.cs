namespace Courir.IBusiness
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Courir.BusinessObject;

    public interface IModelBusiness : IDisposable
    {
        Task<KeyValuePair<bool, Model>> Create(Model itemToCreate);

        Task<KeyValuePair<bool, Model>> Delete(int id);

        Task<Model> Get(int id);

        Task<List<Model>> List();

        Task<Dictionary<int, Model>> ListGroupById();

        Task<KeyValuePair<bool, Model>> Update(int id, Model itemToUpdate);
    }
}