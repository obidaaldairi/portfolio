using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //constraint
            modelBuilder.Entity<Owner>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<PortfolioItem>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Owner>().HasData(
                new Owner()
                {
                    Id = Guid.NewGuid(),
                    Avatar = "1.jfif",
                    FullName = "Obida Aldairi",
                    Profile = ".NET DEVELOPER"
                });
            modelBuilder.Entity<PortfolioItem>().HasData(
                new PortfolioItem()
                {
                    Id = Guid.NewGuid(),
                    ProjectName = "FCE.CO",
                    ProjectImg = "7.png",
                    Description = "An engineering consulting system was developed Providing" +
                    " clients with easy access to consulting services," +" producing clean," +
                    " efficient code based on specifications, easy handling by the project managers."
                });
        }
        public DbSet<Owner> Owner { get; set; }
        public DbSet<PortfolioItem> PortfolioItems { get; set; }

    }
}
