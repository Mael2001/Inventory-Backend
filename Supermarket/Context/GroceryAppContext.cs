using System;
using Microsoft.EntityFrameworkCore;
using Supermarket.Models;

namespace Supermarket.Context
{
    public class GroceryAppContext: DbContext
    {
        public GroceryAppContext(DbContextOptions options)
        : base(options)
        {
            
        }
        public DbSet<Groceries> Grocery { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Groceries>().HasKey(k => k.id);
            modelBuilder.Entity<Groceries>().Property(k => k.id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Groceries>().Property(k => k.name).HasMaxLength(500);


            modelBuilder.Entity<Groceries>().HasData(
                new Groceries
            {
               name = "Comida 1",
               description = "Descripcion 1",
               expirationDate = DateTime.Now,
               id = -1,
               imageURL = "https://images-prod.healthline.com/hlcmsresource/images/AN_images/healthy-eating-ingredients-1296x728-header.jpg",
               measurementType = "Lb",
               quantity = 20
                });
        
        }
    }
}