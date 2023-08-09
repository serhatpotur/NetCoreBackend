using NetCoreBackend.Core.DataAccess.EntityFramework;
using NetCoreBackend.DataAccess.Abstract;
using NetCoreBackend.DataAccess.Concrate.Context;
using NetCoreBackend.Entities.Concrate;

namespace NetCoreBackend.DataAccess.Concrate.EntityFramework;

public class EfOrderDal : EfEntityRepositoryBase<Order, NorthwindContext>, IOrderDal
{
}
