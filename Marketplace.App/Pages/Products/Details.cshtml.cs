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
    public class DetailsModel : PageModel
    {
        private readonly Marketplace.App.DataBase.Context.MarketPlaceDbContext _context;

        public DetailsModel(Marketplace.App.DataBase.Context.MarketPlaceDbContext context)
        {
            _context = context;
        }

        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
