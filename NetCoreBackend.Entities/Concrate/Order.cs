﻿using NetCoreBackend.Core.Entities;

namespace NetCoreBackend.Entities.Concrate;

public class Order : IEntity
{
    public int OrderId { get; set; }
    public string CustomerId { get; set; }
    public int EmployeeId { get; set; }
    public DateTime OrderDate { get; set; }
    public string ShipCity { get; set; }
}
