using System.Linq;
using Basket.Models.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Basket.Models.Persistence
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app) {
            BasketDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<BasketDbContext>();

            if (context.Database.GetPendingMigrations().Any()) {
                context.Database.Migrate();
            }

            if (!context.Forms.Any()) {
                context.Forms.AddRange(
                    new Form {
                        Name = "Kayak", Description = "A boat for one person"
                    },
                    new Form {
                        Name = "Lifejacket",
                        Description = "Protective and fashionable"
                    },
                    new Form {
                        Name = "Soccer Ball",
                        Description = "FIFA-approved size and weight"
                    },
                    new Form {
                        Name = "Corner Flags",
                        Description = "Give your playing field a professional touch"
                    },
                    new Form {
                        Name = "Stadium",
                        Description = "Flat-packed 35,000-seat stadium"
                    },
                    new Form {
                        Name = "Thinking Cap",
                        Description = "Improve brain efficiency by 75%"
                    },
                    new Form {
                        Name = "Unsteady Chair",
                        Description = "Secretly give your opponent a disadvantage"
                    },
                    new Form {
                        Name = "Human Chess Board",
                        Description = "A fun game for the family"
                    },
                    new Form {
                        Name = "Bling-Bling King",
                        Description = "Gold-plated, diamond-studded King"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}