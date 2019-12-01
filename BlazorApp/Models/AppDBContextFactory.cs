using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Models
{
    public class AppDBContextFactory : IDesignTimeDbContextFactory<AppDBContext>
    {
        public AppDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDBContext>();
            var connStr = ConfigurationHelper.GetCurrentSettings("ConnectionStrings:BlazorConnection");
            optionsBuilder.UseSqlServer(connStr);
            return new AppDBContext(optionsBuilder.Options);
        }
        
    }
}
