using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketPlace.Web.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MarketPlace.Web.TestData;
using System.Text.RegularExpressions;
using System.IO;
//using MarketPlace.Core;
//using MarketPlace.DbAccess;

namespace MarketPlace.Web.Controllers
{
    [Route("api/[controller]")]
    public class MarketController : Controller
    {
        // GET: Market
        [HttpGet("[action]")]
        public MarketsModel Index(int page = 0, string filter = "")
        {
            int index = page * 10;
            var marketList = new List<string>();
            foreach(var market in TestData.TestData.Markets)
            {
                marketList.Add(market.Name);
            }
            if(filter != null)
                marketList = marketList.Where(x => x.ToLower().Contains(filter.ToLower())).ToList();
            if (index > marketList.Count)
                index = 0;
            int length = (index + 10 > marketList.Count ? marketList.Count - index : 10);
            var result = new MarketsModel
            {
                maxPage = marketList.Count % 10 == 0 ? marketList.Count / 10 - 1 : marketList.Count / 10,
                Name = marketList.GetRange(index, length).AsEnumerable()
            };
            return result;
        }
        

        [HttpGet("[action]")]
        public MarketModel Details(int page = 0, string name = "")
        {
            int index = page * 2;
            var tmp = TestData.TestData.Markets.First(x => x.Name == name);
            if (index > tmp.Products.Count || index < 0)
                index = 0;
            int pLength = index + 2 > tmp.Products.Count ? tmp.Products.Count - index : 2;

            var result = new MarketModel { Name = tmp.Name, Products = tmp.Products.AsEnumerable() };
                
            result.Products = tmp.Products.GetRange(index, pLength).AsEnumerable();
            result.MaxPage = tmp.Products.Count % 2 == 0 ? tmp.Products.Count / 2 - 1 : tmp.Products.Count / 2;
            return result;
        }

        [HttpPost("[action]")]
        public bool Create([FromBody]string market)
        {
            var bodyStream = this.HttpContext.Request.Body;

            if(bodyStream.CanSeek)
            {
                bodyStream.Seek(0, System.IO.SeekOrigin.Begin);
                using (var ms = new MemoryStream())
                {
                    bodyStream.CopyTo(ms);
                    var txt = System.Text.Encoding.UTF8.GetString(ms.ToArray());
                    Console.WriteLine(txt);
                }
            }


            if (market != null && !TestData.TestData.Markets.Any(x => x.Name == market))
            {
                TestData.TestData.Markets.Add(new Market { Name = market, Categories = new List<ProductsCategory>(), Products = new List<Product>() });
                return true;
            }
            return false;
        }
    }
}