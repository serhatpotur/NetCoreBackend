using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetCoreBackend.Core.Utilities.Results.Abstract;

namespace NetCoreBackend.Core.Utilities.Results.Concrate
{
    public class Result : IResult
    {
        // This : Bu demek. Bu sınıfa ait ctor çalıştır demek
        // this(success) : bu sınıfa ait ctorlardan tek parametreli olanı da kapsa
        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }
        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
