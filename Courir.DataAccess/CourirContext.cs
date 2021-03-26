namespace Courir.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Courir.DataAccess.Configuration;
    using Courir.DataAccess.Seed;
    using Courir.Entities;

    using Microsoft.EntityFrameworkCore;

    public class CourirContext : DbContext
    {
        public CourirContext(DbContextOptions<CourirContext> options)
               : base(options)
        {
        }

        public DbSet<ModelEntity> Models { get; set; }

        public DbSet<StockEntity> Stocks { get; set; }

        public async Task EnsureSeedData(bool isProduction)
        {
            ContextInitializer initializer = new ContextInitializer();
            await initializer.Seed(this, isProduction);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Action> listConfiguration = new List<Action>
            {
                new ModelConfiguration(modelBuilder).Execute,
                new StockConfiguration(modelBuilder).Execute,
            };

            foreach (Action action in listConfiguration)
            {
                action.Invoke();
            }
        }
    }
}