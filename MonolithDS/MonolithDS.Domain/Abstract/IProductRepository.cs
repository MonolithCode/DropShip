using System.Collections.Generic;
using MonolithDS.Domain.Entities;

namespace MonolithDS.Domain.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
    }
}