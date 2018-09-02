using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marketplace.App.DataBase.Context;
using Marketplace.App.DataBase.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.App.Pages
{
    public class MarketsModel : PageModel
    {
        private readonly MarketPlaceDbContext dbContext;

        public MarketsModel(MarketPlaceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet()
        {
            this.Markets = this.dbContext.Markets.ToList();
        }

        public IEnumerable<Market> Markets { get; set; }
    }
}