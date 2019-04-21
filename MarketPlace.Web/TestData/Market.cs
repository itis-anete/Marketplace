using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketPlace.Web.TestData
{
    public class Market
    {
        public string Name { get; set; }

        public void AddProduct(Product product)
        {
            Products.Add(product);
            foreach (var a in product.Categories)
                if (!Categories.Contains(a))
                    Categories.Add(a);
        }

        public List<Product> Products { get; set; }
        public List<ProductsCategory> Categories { get; set; }
    }
}
