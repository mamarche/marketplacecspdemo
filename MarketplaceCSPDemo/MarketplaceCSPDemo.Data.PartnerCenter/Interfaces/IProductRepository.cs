using Microsoft.Store.PartnerCenter.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceCSPDemo.Data.PartnerCenter.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetOrderByTargetAndSegment(string country,string target, string segment);

    }
}
