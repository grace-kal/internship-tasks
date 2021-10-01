using SoftwareCompanyTicketSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareCompanyTicketSystem.App.Seeder
{
    public interface IRoleSeeder
    {
        Task SeedAsync(AppDbContext dbContext, IServiceProvider serviceProvider);
    }
}
