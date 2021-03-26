namespace Courir.DataAccess.Seed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Courir.Entities;

    public class StockSeed : IContextSeed
    {
        public StockSeed(CourirContext context)
        {
            this.Context = context;
        }

        public CourirContext Context { get; set; }

        public async Task Execute(bool isProduction)
        {
            if (!this.Context.Stocks.Any() && !isProduction)
            {
                DateTime createdDate = DateTime.UtcNow;
                List<StockEntity> stocks = new List<StockEntity>
                {
                    new StockEntity
                    {
                        IdModel = 1,
                        CreatedDate = createdDate,
                        Price = 50.8f,
                        ShoeSize = ShoeSize.S40,
                        Quantity = 40,
                    },
                    new StockEntity
                    {
                        IdModel = 2,
                        CreatedDate = createdDate,
                        Price = 58,
                        ShoeSize = ShoeSize.S39_5,
                        Quantity = 20,
                    },
                };

                await this.Context.Stocks.AddRangeAsync(stocks);
                await this.Context.SaveChangesAsync();
            }
        }
    }
}