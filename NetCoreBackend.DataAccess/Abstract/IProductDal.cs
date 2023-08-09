using NetCoreBackend.Core.DataAccess;
using NetCoreBackend.Entities.Concrate;
using NetCoreBackend.Entities.DTOs;

namespace NetCoreBackend.DataAccess.Abstract;

public interface IProductDal : IEntityRepository<Product>
{
    List<ProductDetailDto> GetProductDetails();
}
