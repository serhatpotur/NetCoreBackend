﻿using NetCoreBackend.Core.Utilities.Results.Abstract;
using NetCoreBackend.Entities.Concrate;
using NetCoreBackend.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreBackend.Business.Abstract
{
    public interface IProductService : IEntityService<Product>
    {
        IDataResult<List<Product>> GetAllByCategoryList(int categoryId);
        IDataResult<List<Product>> GetByUnitPrice(decimal minPrice, decimal maxPrice);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
    }
}
