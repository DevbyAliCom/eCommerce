using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext dbContext)
        {
            if (!dbContext.Products.Any())
            {
                // Define Categories with hierarchy
                var cosmeticsCategory = new Category
                {
                    Name = "Cosmetics",
                    Description = "Beauty and personal care products",
                    SubCategories = new List<Category>
                {
                    new Category { Name = "Face", Description = "Face cosmetics" },
                    new Category { Name = "Eyes", Description = "Eye makeup and care products" },
                    new Category { Name = "Lips", Description = "Lip care products" }
                }
                };

                dbContext.Categories.Add(cosmeticsCategory);

                // Define Tags
                var tags = new List<Tag>
            {
                new Tag { Name = "Organic" },
                new Tag { Name = "Vegan" },
                new Tag { Name = "Cruelty-Free" },
                new Tag { Name = "Waterproof" },
                new Tag { Name = "Long-Lasting" },
                new Tag { Name = "Matte Finish" },
                new Tag { Name = "Moisturizing" },
                new Tag { Name = "SPF Protection" },
                new Tag { Name = "Anti-Aging" },
                new Tag { Name = "Hypoallergenic" }
            };

                dbContext.Tags.AddRange(tags);

                // Define Products with tags and category relationships
                var products = new List<Product>
            {
                new Product
                {
                    Name = "Hydrating Face Primer",
                    Description = "A lightweight, hydrating primer for smooth makeup application.",
                    Price = 15.99m,
                    PictureUrl = "/images/face_primer.jpg",
                    SKU = "C-FP001",
                    Brand = "BeautyCo",
                    QtyInStock = 50,
                    DateAdded = DateTime.UtcNow,
                    Category = cosmeticsCategory.SubCategories.First(c => c.Name == "Face"),
                    //Tags = new List<ProductTag>
                    //{
                    //    new ProductTag { Product = null, Tag = tags[0] }, // This needs to be fixed
                    //    new ProductTag { Product = null, Tag = tags[6] }  // This needs to be fixed
                    //}
                },
                new Product
                {
                    Name = "Long-Lasting Liquid Eyeliner",
                    Description = "A waterproof eyeliner for a precise, bold look.",
                    Price = 12.50m,
                    PictureUrl = "/images/liquid_eyeliner.jpg",
                    SKU = "C-EL001",
                    Brand = "GlamEyes",
                    QtyInStock = 80,
                    DateAdded = DateTime.UtcNow,
                    Category = cosmeticsCategory.SubCategories.First(c => c.Name == "Eyes"),
                },
                new Product
                {
                    Name = "SPF 30 Tinted Moisturizer",
                    Description = "A tinted moisturizer with SPF protection and hydration.",
                    Price = 20.99m,
                    PictureUrl = "/images/tinted_moisturizer.jpg",
                    SKU = "C-TM001",
                    Brand = "SunGuard",
                    QtyInStock = 40,
                    DateAdded = DateTime.UtcNow,
                    Category = cosmeticsCategory.SubCategories.First(c => c.Name == "Face"),
                },
                new Product
                {
                    Name = "Matte Lipstick - Rose Red",
                    Description = "A bold, long-lasting matte lipstick in rose red.",
                    Price = 9.99m,
                    PictureUrl = "/images/matte_lipstick.jpg",
                    SKU = "C-LS001",
                    Brand = "LuxBeauty",
                    QtyInStock = 70,
                    DateAdded = DateTime.UtcNow,
                    Category = cosmeticsCategory.SubCategories.First(c => c.Name == "Lips"),
     
                },
                new Product
                {
                    Name = "Anti-Aging Eye Cream",
                    Description = "A rejuvenating eye cream for reducing wrinkles and puffiness.",
                    Price = 25.99m,
                    PictureUrl = "/images/eye_cream.jpg",
                    SKU = "C-EC001",
                    Brand = "YouthRevive",
                    QtyInStock = 30,
                    DateAdded = DateTime.UtcNow,
                    Category = cosmeticsCategory.SubCategories.First(c => c.Name == "Eyes"),
                  
                }
            };

        

                // Add products to the context
                dbContext.Products.AddRange(products);

                // Save changes to the database
                await dbContext.SaveChangesAsync();
            }
        }
    }

}
