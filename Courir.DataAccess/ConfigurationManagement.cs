﻿namespace Courir.DataAccess
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public abstract class ConfigurationManagement<T> : IConfigurationManagement where T : class
    {
        public ConfigurationManagement(ModelBuilder modelBuilder)
        {
            this.EntityConfiguration = modelBuilder.Entity<T>();
        }

        protected EntityTypeBuilder<T> EntityConfiguration { get; }

        public void Execute()
        {
            this.ProcessTable();
            this.ProcessConstraint();
            this.ProcessForeignKey();
            this.ProcessIndex();
        }

        protected abstract void ProcessConstraint();

        protected abstract void ProcessForeignKey();

        protected abstract void ProcessIndex();

        protected abstract void ProcessTable();
    }
}