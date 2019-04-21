using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketPlace.Web.ViewModel
{
    public class MarketsModel
    {
        public IEnumerable<string> Name { get; set; }
        public int maxPage { get; set; }
    }
}
