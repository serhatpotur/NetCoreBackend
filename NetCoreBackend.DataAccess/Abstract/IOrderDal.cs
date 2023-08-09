using NetCoreBackend.Core.DataAccess;
using NetCoreBackend.Entities.Concrate;

namespace NetCoreBackend.DataAccess.Abstract;

public interface IOrderDal : IEntityRepository<Order>
{
}
