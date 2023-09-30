using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesDataTables.Models;

namespace RazorPagesDataTables.Data
{
    public class RazorPagesDataTablesContext : DbContext
    {
        public RazorPagesDataTablesContext (DbContextOptions<RazorPagesDataTablesContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesDataTables.Models.Product> Product { get; set; } = default!;
    }
}
