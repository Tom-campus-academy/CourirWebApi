namespace Courir.DataAccess.Configuration
{
    using Courir.Entities;

    using Microsoft.EntityFrameworkCore;

    public class StockConfiguration : ConfigurationManagement<StockEntity>
    {
        public StockConfiguration(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        protected override void ProcessConstraint()
        {
            this.EntityConfiguration.HasKey(x => x.Id);
            this.EntityConfiguration.Property(x => x.Price).IsRequired(true).HasColumnType("double");
            this.EntityConfiguration.Property(x => x.Quantity).IsRequired(true).HasColumnType("int");
            this.EntityConfiguration.Property(x => x.ShoeSize).IsRequired(true).HasColumnType("int");
        }

        protected override void ProcessForeignKey()
        {
            this.EntityConfiguration.HasOne(x => x.Model).WithMany().IsRequired(true).HasForeignKey(x => x.IdModel).OnDelete(DeleteBehavior.Cascade);
        }

        protected override void ProcessIndex()
        {
        }

        protected override void ProcessTable()
        {
            this.EntityConfiguration.ToTable("Stocks");
        }
    }
}