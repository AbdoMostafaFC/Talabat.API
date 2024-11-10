using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Repository.Data
{
    public static class SeedData
    {

        public async static Task Seed(StoreContext context)
        {

            if (!context.brands.Any())
            {
                var brands = File.ReadAllText("../Talabat.Repository/Data/dataSedding/brands.json");

                var brans = JsonSerializer.Deserialize<List<Brand>>(brands);
                  
                if (brans?.Count() > 0)
                {
                    foreach (var brand in brans)
                    {

                        await context.Set<Brand>().AddAsync(brand);

                    }
                    context.SaveChanges();
                } 
            }

            if (!context.categories.Any())
            {
                var category = File.ReadAllText("../Talabat.Repository/Data/dataSedding/categories.json");

                var categories = JsonSerializer.Deserialize<List<Category>>(category);

                if (categories?.Count() > 0)
                {
                    foreach (var cat in categories)
                    {

                        await context.Set<Category>().AddAsync(cat);

                    }
                    context.SaveChanges();
                }
            }
            if (!context.Products.Any())
            {
                var product = File.ReadAllText("../Talabat.Repository/Data/dataSedding/products.json");

                var products = JsonSerializer.Deserialize<List<Product>>(product);

                if (products?.Count() > 0)
                {
                    foreach (var catego in products)
                    {

                        await context.Set<Product>().AddAsync(catego);

                    }
                    context.SaveChanges();
                }
            }

        }
    }
}
