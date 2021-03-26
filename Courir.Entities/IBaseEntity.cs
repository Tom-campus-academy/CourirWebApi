﻿namespace Courir.Entities
{
    using System;

    public interface IBaseEntity
    {
        DateTime CreatedDate { get; set; }

        DateTime? UpdatedDate { get; set; }
    }
}