using Microsoft.Extensions.Logging;
using Stores.Data.Context;
using Stores.Data.Entities;
using System.Text.Json;

namespace Stores.Reposatory
{
    public class StortesContextSeed
    {
        public static async Task SeedAsync(StoresDBContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (context.ProductBrand != null && !context.ProductBrand.Any())
                {
                    var brandsData = File.ReadAllText("../Stores.Reposatory/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    if (brands is not null)
                        await context.ProductBrand.AddRangeAsync(brands);
                }

                if (context.ProductType != null && !context.ProductType.Any())
                {
                    var typesData = File.ReadAllText("../Stores.Reposatory/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductTypes>>(typesData);

                    if (types is not null)
                        await context.ProductType.AddRangeAsync(types);
                }
                if (context.Products != null && !context.Products.Any())
                {
                    var productsData = File.ReadAllText("../Stores.Reposatory/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    if (products is not null)
                    {
                       
                        await context.Products.AddRangeAsync(products);
                    }
                }
        await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StortesContextSeed>();
                logger.LogError(ex, "An error occurred during seeding data.");
            }
        }
    }
}
