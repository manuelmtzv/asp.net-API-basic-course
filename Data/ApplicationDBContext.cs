using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using start.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace start.Data
{
    public class ApplicationDBContext(DbContextOptions dbContextOptions) : IdentityDbContext<User>(dbContextOptions)
    {
        public DbSet<Stock> Stocks { get; set; }

        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<IdentityRole> roles =
            [
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Name = "User", NormalizedName = "USER" }
            ];

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}