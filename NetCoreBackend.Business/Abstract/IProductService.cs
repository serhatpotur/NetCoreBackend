using NetCoreBackend.Entities.Concrate;
using NetCoreBackend.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreBackend.Business.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> GetAllByCategoryList(int categoryId);
        List<Product> GetByUnitPrice(decimal minPrice, decimal maxPrice);
        List<ProductDetailDto> GetProductDetails();
    }
}
