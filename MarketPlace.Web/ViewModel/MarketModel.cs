using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketPlace.Web.TestData;

namespace MarketPlace.Web.ViewModel
{
    public class MarketModel
    {
        public string Name { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public int MaxPage { get; set; }
    }
}
