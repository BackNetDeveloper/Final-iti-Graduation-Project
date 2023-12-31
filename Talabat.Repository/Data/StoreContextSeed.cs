﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Entities.Order_Aggregate;

namespace Talabat.Repository.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
			try
			{
				if (context.ProductBrands != null && !context.ProductBrands.Any())
				{
					var BrandsData = File.ReadAllText("../Talabat.Repository/Data/SeedData/brands.json");
					var Brands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandsData);
					if (Brands is not null && Brands.Count > 0)
					{
						foreach (var Brand in Brands)
							await context.Set<ProductBrand>().AddAsync(Brand);

						await context.SaveChangesAsync();
					}
				}
			
				if (context.ProductTypes != null && !context.ProductTypes.Any())
				{
					var TypesData = File.ReadAllText("../Talabat.Repository/Data/SeedData/types.json");
					var Types = JsonSerializer.Deserialize<List<ProductType>>(TypesData);
					if (Types is not null && Types.Count > 0)
					{
						foreach (var Type in Types)
							await context.Set<ProductType>().AddAsync(Type);
						await context.SaveChangesAsync();
					}
				}
				if (context.DeliveryMethods != null && !context.DeliveryMethods.Any())
				{
					var DeliveryMethodsData = File.ReadAllText("../Talabat.Repository/Data/SeedData/delivery.json");
					var DeliveryMethods = JsonSerializer.Deserialize<List<DeliveryMethod>>(DeliveryMethodsData);
					if (DeliveryMethods is not null && DeliveryMethods.Count > 0)
					{
						foreach (var DeliveryMethod in DeliveryMethods)
							await context.Set<DeliveryMethod>().AddAsync(DeliveryMethod);
						await context.SaveChangesAsync();
					}
				}

				if (context.Products != null && !context.Products.Any())
				{
					var ProductsData = File.ReadAllText("../Talabat.Repository/Data/SeedData/products.json");
					var Products = JsonSerializer.Deserialize<List<Product>>(ProductsData);
					if (Products is not null && Products.Count > 0)
					{
						foreach (var Product in Products)
							await context.Set<Product>().AddAsync(Product);
						await context.SaveChangesAsync();
					}
				}
			}
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex, ex.Message);
            }

        }
    }
}
