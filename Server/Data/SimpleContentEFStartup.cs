using System;
using System.Threading.Tasks;
using Asp2017.Server.Models;
using AspCoreServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AspCoreServer.Data
{
    public static class SimpleContentEFStartup
    {
        public static async Task InitializeDatabaseAsync(IServiceProvider services)
        {
            var context = services.GetRequiredService<SpaDbContext>();


            if (await context.Estimates.AnyAsync())
            {
                return; // DB has been seeded
            }
            var users = new Estimate[] {
                new Estimate () { ProjectName = "Mark Pieszak" },
                new Estimate () { ProjectName = "Abrar Jahin" },
                new Estimate () { ProjectName = "hakonamatata" },
                new Estimate () { ProjectName = "LiverpoolOwen" },
                new Estimate () { ProjectName = "Ketrex" },
                new Estimate () { ProjectName = "markwhitfeld" },
                new Estimate () { ProjectName = "daveo1001" },
                new Estimate () { ProjectName = "paonath" },
                new Estimate () { ProjectName = "nalex095" },
                new Estimate () { ProjectName = "ORuban" },
                new Estimate () { ProjectName = "Gaulomatic" },
                new Estimate () { ProjectName = "GRIMMR3AP3R" }
            };
            await context.Estimates.AddRangeAsync(users);

            await context.SaveChangesAsync();
        }
    }
}
