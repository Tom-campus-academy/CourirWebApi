namespace Courir.DataAccess.Seed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Courir.Entities;

    public class ModelSeed : IContextSeed
    {
        public ModelSeed(CourirContext context)
        {
            this.Context = context;
        }

        public CourirContext Context { get; set; }

        public async Task Execute(bool isProduction)
        {
            if (!this.Context.Models.Any() && !isProduction)
            {
                DateTime createdDate = DateTime.UtcNow;
                List<ModelEntity> modelEntities = new List<ModelEntity>
                {
                    new ModelEntity
                    {
                        Name = "Sneakers",
                        CreatedDate = createdDate,
                        Brand = Brand.Adidas,
                        IdentificationNumber = "A58208B98F",
                    },
                    new ModelEntity
                    {
                        Name = "Converse 2008",
                        CreatedDate = createdDate,
                        Brand = Brand.Converse,
                        IdentificationNumber = "A58208B98PG",
                    },
                };

                await this.Context.Models.AddRangeAsync(modelEntities);
                await this.Context.SaveChangesAsync();
            }
        }
    }
}