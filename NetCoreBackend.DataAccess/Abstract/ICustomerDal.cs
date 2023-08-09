using NetCoreBackend.Core.DataAccess;
using NetCoreBackend.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreBackend.DataAccess.Abstract;

public interface ICustomerDal : IEntityRepository<Customer>
{
}
