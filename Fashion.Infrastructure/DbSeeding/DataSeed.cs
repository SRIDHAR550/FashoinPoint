using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fashion.Infrastructure.DbSeeding
{
    public static class DataSeed
    {
        public static async Task RoleSeed(IServiceProvider serviceProvider)
        {
            var scope = serviceProvider.CreateScope();
            var rolemanager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var roles = new List<IdentityRole> {
                new IdentityRole{Name="Admin",NormalizedName="Admin"},
                new IdentityRole{Name="Customer",NormalizedName="Customer"}
            };
            foreach(var role in roles)
            {
                if (!await rolemanager.RoleExistsAsync(role.Name))
                {
                    await rolemanager.CreateAsync(role);
                }
            }
        }
    }
}
