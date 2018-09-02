using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marketplace.App.DataBase.Context;
using Marketplace.App.DataBase.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.App.Pages.ShowMarket
{
    public class ShowMarketModel : PageModel
    {
        private readonly MarketPlaceDbContext dbContext;

        public ShowMarketModel(MarketPlaceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet(int marketId)
        {
            this.Products = this.dbContext.MarketProduct.Where(x => x.MarketId == marketId)
                .Include(x=>x.Product)
                .ToList()
                .Select(x => x.Product);
        }

        public IEnumerable<Product> Products { get; set; }
    }
}