using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Marketplace.App.DataBase.Context;
using Marketplace.App.DataBase.Entities;

namespace Marketplace.App.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly Marketplace.App.DataBase.Context.MarketPlaceDbContext _context;

        public IndexModel(Marketplace.App.DataBase.Context.MarketPlaceDbContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Products.ToListAsync();
        }
    }
}
