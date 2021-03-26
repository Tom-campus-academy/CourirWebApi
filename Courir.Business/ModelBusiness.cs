namespace Courir.Business
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Courir.BusinessObject;
    using Courir.Entities;
    using Courir.IBusiness;
    using Courir.IDataAccess;

    public class ModelBusiness : IModelBusiness
    {
        private readonly IModelDataAccess dataAccess;

        public ModelBusiness(IModelDataAccess modelDataAccess)
        {
            this.dataAccess = modelDataAccess;
        }

        public async Task<KeyValuePair<bool, Model>> Create(Model itemToCreate)
        {
            if (itemToCreate != null)
            {
                ModelEntity entity = itemToCreate.CreateEntity();

                if (itemToCreate.ValidationService.Validate(entity))
                {
                    if (entity.Id == default)
                    {
                        entity = await this.dataAccess.Create(entity);

                        if (entity != null)
                        {
                            itemToCreate = new Model(entity);
                            return new KeyValuePair<bool, Model>(true, itemToCreate);
                        }
                    }
                }
            }

            itemToCreate.ValidationService.IsValid = false;

            return new KeyValuePair<bool, Model>(false, itemToCreate);
        }

        public async Task<KeyValuePair<bool, Model>> Delete(int id)
        {
            if (id != default)
            {
                Model model = await this.Get(id);

                if (model != null)
                {
                    await this.dataAccess.Delete(id);
                    return new KeyValuePair<bool, Model>(true, model);
                }
            }

            return new KeyValuePair<bool, Model>(false, null);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<Model> Get(int id)
        {
            if (id != default)
            {
                ModelEntity entity = await this.dataAccess.Find(id);

                if (entity != null)
                {
                    return new Model(entity);
                }
            }

            return null;
        }

        public async Task<List<Model>> List()
        {
            List<Model> models = new List<Model>();
            List<ModelEntity> modelEntities = await this.dataAccess.List();
            foreach (var modelEntity in modelEntities)
            {
                models.Add(new Model(modelEntity));
            }

            return models;
        }

        public async Task<Dictionary<int, Model>> ListGroupById()
        {
            List<Model> models = await this.List();

            return models.ToDictionary(x => x.Id, x => x);
        }

        public async Task<KeyValuePair<bool, Model>> Update(int id, Model itemToUpdate)
        {
            if (itemToUpdate != null && id != default)
            {
                itemToUpdate.Id = id;
                ModelEntity entity = itemToUpdate.CreateEntity();

                if (itemToUpdate.ValidationService.Validate(entity))
                {
                    entity = await this.dataAccess.Update(entity, entity.Id);

                    if (entity != null)
                    {
                        itemToUpdate = new Model(entity);
                        return new KeyValuePair<bool, Model>(true, itemToUpdate);
                    }
                }
            }

            itemToUpdate.ValidationService.IsValid = false;

            return new KeyValuePair<bool, Model>(false, itemToUpdate);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.dataAccess?.Dispose();
            }
        }
    }
}