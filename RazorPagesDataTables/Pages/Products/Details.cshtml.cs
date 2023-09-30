using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesDataTables.Data;
using RazorPagesDataTables.Models;

namespace RazorPagesDataTables.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesDataTables.Data.RazorPagesDataTablesContext _context;

        public DetailsModel(RazorPagesDataTables.Data.RazorPagesDataTablesContext context)
        {
            _context = context;
        }

      public Product Product { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            else 
            {
                Product = product;
            }
            return Page();
        }
    }
}
