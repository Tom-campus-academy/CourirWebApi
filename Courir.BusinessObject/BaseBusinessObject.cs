﻿namespace Courir.BusinessObject
{
    using System;

    using Courir.BusinessObject.Validation.Service;
    using Courir.Entities;

    public class BaseBusinessObject<T>
        where T : IBaseEntity
    {
        public BaseBusinessObject()
        {
        }

        public BaseBusinessObject(IBaseEntity entity)
        {
            this.CreatedDate = entity.CreatedDate;
            this.UpdatedDate = entity.UpdatedDate;
        }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public ValidationService<T> ValidationService { get; set; }

        public virtual T CreateEntity()
        {
            return default;
        }
    }
}