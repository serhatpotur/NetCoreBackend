using NetCoreBackend.Core.Entities;

namespace NetCoreBackend.Entities.Concrate;

public class Category : IEntity
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
}
