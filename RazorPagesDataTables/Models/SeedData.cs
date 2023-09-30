using Microsoft.EntityFrameworkCore;
using RazorPagesDataTables.Data;
using System;

namespace RazorPagesDataTables.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesDataTablesContext(
                serviceProvider.GetRequiredService<DbContextOptions<RazorPagesDataTablesContext>>()))
            {
                if (context == null || context.Product == null)
                {
                    throw new ArgumentNullException("Null RazorPagesDataTablesContext");
                }

                // Look for any products.
                if (context.Product.Any())
                {
                    return;   // DB has been seeded
                }

                context.Product.AddRange(
                    new Product
                    {
                        Name = "Product 1",
                        Price = 10.99M,
                        ExpiryDate = DateTime.Parse("2023-10-01")
                    },

                    new Product
                    {
                        Name = "Product 2",
                        Price = 19.99M,
                        ExpiryDate = DateTime.Parse("2023-09-15")
                    },

                    new Product
                    {
                        Name = "Product 3",
                        Price = 5.49M,
                        ExpiryDate = DateTime.Parse("2023-11-05")
                    },

                    new Product
                    {
                        Name = "Product 4",
                        Price = 14.99M,
                        ExpiryDate = DateTime.Parse("2023-10-20")
                    },

                    new Product
                    {
                        Name = "Product 5",
                        Price = 67.99M,
                        ExpiryDate = DateTime.Parse("2023-10-20")
                    },

                    new Product
                    {
                        Name = "Product 6",
                        Price = 22.99M,
                        ExpiryDate = DateTime.Parse("2023-10-20")
                    },

                    new Product
                    {
                        Name = "Product 7",
                        Price = 10.99M,
                        ExpiryDate = DateTime.Parse("2023-10-20")
                    },

                    new Product
                    {
                        Name = "Product 8",
                        Price = 84.99M,
                        ExpiryDate = DateTime.Parse("2023-10-20")
                    },

                    new Product
                    {
                        Name = "Product 9",
                        Price = 34.99M,
                        ExpiryDate = DateTime.Parse("2023-05-20")
                    },

                    new Product
                    {
                        Name = "Product 10",
                        Price = 24.99M,
                        ExpiryDate = DateTime.Parse("2043-10-10")
                    },

                    new Product
                    {
                        Name = "Product 11",
                        Price = 13.99M,
                        ExpiryDate = DateTime.Parse("2025-10-20")
                    },

                    new Product
                    {
                        Name = "Product 12",
                        Price = 16.99M,
                        ExpiryDate = DateTime.Parse("2024-10-20")
                    },

                    new Product
                    {
                        Name = "Product 13",
                        Price = 18.99M,
                        ExpiryDate = DateTime.Parse("2023-10-24")
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
