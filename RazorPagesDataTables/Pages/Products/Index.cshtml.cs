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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesDataTables.Data.RazorPagesDataTablesContext _context;

        public IndexModel(RazorPagesDataTables.Data.RazorPagesDataTablesContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Product != null)
            {
                Product = await _context.Product.ToListAsync();
            }
        }
    }
}
