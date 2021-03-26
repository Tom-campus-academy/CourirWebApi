namespace Courir.DataAccess.Configuration
{
    using Courir.Entities;

    using Microsoft.EntityFrameworkCore;

    public class ModelConfiguration : ConfigurationManagement<ModelEntity>
    {
        public ModelConfiguration(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        protected override void ProcessConstraint()
        {
            this.EntityConfiguration.HasKey(x => x.Id);
            this.EntityConfiguration.Property(x => x.Name).IsRequired(true).HasColumnType("varchar(1000)");
            this.EntityConfiguration.Property(x => x.Brand).IsRequired(true).HasColumnType("int");
            this.EntityConfiguration.Property(x => x.IdentificationNumber).IsRequired(true).HasColumnType("varchar(1000)");
        }

        protected override void ProcessForeignKey()
        {
        }

        protected override void ProcessIndex()
        {
        }

        protected override void ProcessTable()
        {
            this.EntityConfiguration.ToTable("Models");
        }
    }
}