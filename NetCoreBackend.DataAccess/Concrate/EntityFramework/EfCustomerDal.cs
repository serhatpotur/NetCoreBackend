using NetCoreBackend.Core.DataAccess.EntityFramework;
using NetCoreBackend.DataAccess.Abstract;
using NetCoreBackend.DataAccess.Concrate.Context;
using NetCoreBackend.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreBackend.DataAccess.Concrate.EntityFramework;

public class EfCustomerDal : EfEntityRepositoryBase<Customer, NorthwindContext>, ICustomerDal
{

}
