using BookiFy.Data.Interfaces;
using BookiFy.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookiFy.Data.Repositories
{
    public class DbIntializer : IDbIntializer
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public DbIntializer(IServiceScopeFactory scopeFactory)
        {
            this._scopeFactory = scopeFactory;
        }

        public void Initialize()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<AppDbContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
        private static Dictionary<string, Category> categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var genresList = new Category[]
                    {
                        new Category { CategoryName = "Used", Description="All used" },
                        new Category { CategoryName = "New", Description="All new" }
                    };

                    categories = new Dictionary<string, Category>();

                    foreach (Category genre in genresList)
                    {
                        categories.Add(genre.CategoryName, genre);
                    }
                }

                return categories;
            }
        }
        public void SeedData()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<AppDbContext>())
                {
                    if (!context.Categories.Any())
                    {

                        context.Categories.AddRange(Categories.Select(c => c.Value));

                    }
                    //add admin user
                    if (!context.Items.Any())
                    {
                        context.Items.AddRange(

                        new Item { ItemName = "Dell", ShortDescription = "used", Price = 99, LongDescription = "used for 2 years", Category = Categories["Used"], InStock = true, Image = "a2.jpg" },
                        new Item { ItemName = "Apple", ShortDescription = "New", Price = 49, LongDescription = "newly built", Category = Categories["Used"], InStock = false, Image = "a3.jpg" },
                        new Item { ItemName = "HP", ShortDescription = "New", Price = 59, LongDescription = "newly built", Category = Categories["Used"], InStock = false, Image = "a3.jpg" },
                        new Item { ItemName = "Microsoft", ShortDescription = "New", Price = 69, LongDescription = "newly built", Category = Categories["New"], InStock = false, Image = "a3.jpg" },
                        new Item { ItemName = "Toshiba", ShortDescription = "New", Price = 979, LongDescription = "newly built", Category = Categories["New"], InStock = false, Image = "a3.jpg" },
                        new Item { ItemName = "Razer", ShortDescription = "Razer", Price = 09, LongDescription = "newly built", Category = Categories["New"], InStock = true, Image = "a3.jpg" },
                        new Item { ItemName = "Razer", ShortDescription = "Razer", Price = 199, LongDescription = "newly built", Category = Categories["New"], InStock = true, Image = "a3.jpg" }
                        );
                    }


                    context.SaveChanges();
                }
            }
        }
    }
}
