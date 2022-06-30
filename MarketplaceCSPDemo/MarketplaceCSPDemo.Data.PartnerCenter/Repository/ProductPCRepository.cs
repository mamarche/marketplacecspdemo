using MarketplaceCSPDemo.Data.PartnerCenter.Context;
using MarketplaceCSPDemo.Data.PartnerCenter.Interfaces;
using Microsoft.Store.PartnerCenter.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MarketplaceCSPDemo.Data.PartnerCenter.Repository
{
    public class ProductPCRepository : IProductRepository
    {
        private readonly PartnerCenterContext _context;
        public ProductPCRepository(PartnerCenterContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetOrderByTargetAndSegment(string country,string target, string segment)
        {
            IEnumerable<Product>? _products = null;

          

            if(string.IsNullOrEmpty(target) && string.IsNullOrEmpty(segment))
                _products = _context.aggregatePartner.Products.ByCountry(country).ByTargetView(target).ByTargetSegment(segment).Get().Items;
            else
              _products = _context.aggregatePartner.Products.ByCountry(country).ByTargetView(target).Get().Items;


            return _products;
        }
    }
}
