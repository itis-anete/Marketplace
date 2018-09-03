﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Marketplace.App.DataBase.Context;
using Marketplace.App.DataBase.Entities;

namespace Marketplace.App.Pages.FillMarket
{
    public class EditModel : PageModel
    {
        private readonly Marketplace.App.DataBase.Context.MarketPlaceDbContext _context;

        public EditModel(Marketplace.App.DataBase.Context.MarketPlaceDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MarketProduct MarketProduct { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MarketProduct = await _context.MarketProduct
                .Include(m => m.Market)
                .Include(m => m.Product).FirstOrDefaultAsync(m => m.Id == id);

            if (MarketProduct == null)
            {
                return NotFound();
            }
           ViewData["MarketId"] = new SelectList(_context.Markets, "Id", "Id");
           ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MarketProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarketProductExists(MarketProduct.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MarketProductExists(int id)
        {
            return _context.MarketProduct.Any(e => e.Id == id);
        }
    }
}