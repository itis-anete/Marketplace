using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Marketplace.App.DataBase.Context;
using Marketplace.App.DataBase.Entities;

namespace Marketplace.App.Pages.FillMarket
{
    public class CreateModel : PageModel
    {
        private readonly Marketplace.App.DataBase.Context.MarketPlaceDbContext _context;

        public CreateModel(Marketplace.App.DataBase.Context.MarketPlaceDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["MarketId"] = new SelectList(_context.Markets, "Id", "Id");
        ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public MarketProduct MarketProduct { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MarketProduct.Add(MarketProduct);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}