namespace Courir.Business
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Courir.BusinessObject;
    using Courir.Entities;
    using Courir.IBusiness;
    using Courir.IDataAccess;

    public class StockBusiness : IStockBusiness
    {
        private readonly IStockDataAccess dataAccess;

        private readonly IModelBusiness modelBusiness;

        public StockBusiness(IStockDataAccess stockDataAccess, IModelBusiness modelBusiness)
        {
            this.dataAccess = stockDataAccess;
            this.modelBusiness = modelBusiness;
        }

        public async Task<KeyValuePair<bool, Stock>> Create(Stock itemToCreate)
        {
            if (itemToCreate != null)
            {
                StockEntity entity = itemToCreate.CreateEntity();

                if (itemToCreate.ValidationService.Validate(entity))
                {
                    if (entity.Id == default)
                    {
                        entity = await this.dataAccess.Create(entity);

                        if (entity != null)
                        {
                            itemToCreate = await this.GetFromEntity(entity);
                            return new KeyValuePair<bool, Stock>(true, itemToCreate);
                        }
                    }
                }
            }

            itemToCreate.ValidationService.IsValid = false;

            return new KeyValuePair<bool, Stock>(false, itemToCreate);
        }

        public async Task<KeyValuePair<bool, Stock>> Delete(int id)
        {
            if (id != default)
            {
                Stock model = await this.Get(id);

                if (model != null)
                {
                    await this.dataAccess.Delete(id);
                    return new KeyValuePair<bool, Stock>(true, model);
                }
            }

            return new KeyValuePair<bool, Stock>(false, null);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<Stock> Get(int id)
        {
            if (id != default)
            {
                StockEntity entity = await this.dataAccess.Find(id);

                if (entity != null)
                {
                    return await this.GetFromEntity(entity);
                }
            }

            return null;
        }

        public async Task<List<Stock>> List()
        {
            List<StockEntity> modelEntities = await this.dataAccess.List();
            return await this.GetFromEntities(modelEntities);
        }

        public async Task<KeyValuePair<bool, Stock>> Update(int id, Stock itemToUpdate)
        {
            if (itemToUpdate != null && id != default)
            {
                itemToUpdate.Id = id;
                StockEntity entity = itemToUpdate.CreateEntity();

                if (itemToUpdate.ValidationService.Validate(entity))
                {
                    entity = await this.dataAccess.Update(entity, entity.Id);

                    if (entity != null)
                    {
                        itemToUpdate = await this.GetFromEntity(entity);
                        return new KeyValuePair<bool, Stock>(true, itemToUpdate);
                    }
                }
            }

            itemToUpdate.ValidationService.IsValid = false;

            return new KeyValuePair<bool, Stock>(false, itemToUpdate);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.dataAccess?.Dispose();
                this.modelBusiness?.Dispose();
            }
        }

        private async Task<List<Stock>> GetFromEntities(List<StockEntity> stockEntities)
        {
            List<Stock> stocks = new List<Stock>();
            Dictionary<int, Model> result = await this.modelBusiness.ListGroupById();

            foreach (var stockEntity in stockEntities)
            {
                Stock stock = new Stock(stockEntity);
                stock.Model = result[stock.IdModel];
                stocks.Add(stock);
            }

            return stocks;
        }

        private async Task<Stock> GetFromEntity(StockEntity stockEntity)
        {
            Stock stock = new Stock(stockEntity);
            stock.Model = await this.modelBusiness.Get(stock.IdModel);

            return stock;
        }
    }
}