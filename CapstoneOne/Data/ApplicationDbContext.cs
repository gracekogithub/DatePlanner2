using CapstoneOne.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneOne.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
            .HasData(
            new IdentityRole
            {
                Id = "c89c2b1a-1ced-4496-9297-6586488a5aa9",
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = "c94edec3-c136-4227-ae5a-235d26f5d8e6"

            },
            new IdentityRole
            {
                Id= "4f4efb36-63f5-4099-b8a3-198c25a14b8e",
                Name = "Customer",
                NormalizedName = "CUSTOMER",
                ConcurrencyStamp = "7301bbcc-1823-4485-aa0a-2d437ca86768"
            }
            );
            builder.Entity<Product>()
            .HasData(
                    new Product { ProductId = 1, Name = "Planner Package", Description = "Let Us Do All The Planning For Your Date!", Price = 35 },
                    new Product { ProductId = 2, Name = "Reminder Package", Description = "Text/Email/Location Reminders", Price = 25 },
                    new Product { ProductId = 3, Name = "Transport Package", Description = "Too Lazy? We'll Pick You Up!", Price = 500 },
                    new Product { ProductId = 4, Name = "Deluxe Package", Description = "Includes: Vacations, Hotels, Flights", Price = 1000 },
                    new Product { ProductId = 5, Name = "Custom Package", Description = "Customize Your Own Package!", Price = 200 }
            );

            builder.Entity<CustomerProduct>()
                .HasKey(cp => new { cp.CustomerId, cp.ProductId });
            builder.Entity<CustomerProduct>()
                .HasOne(cp => cp.Customer)
                .WithMany(c => c.ShoppingCart)
                .HasForeignKey(cp => cp.CustomerId);
            builder.Entity<CustomerProduct>()
                .HasOne(cp => cp.Product)
                .WithMany(p => p.ShoppingCart)
                .HasForeignKey(cp => cp.ProductId);
        }
        public DbSet<Customer> Customers{ get; set;}
        public DbSet<Admin> Admins{ get; set;}
        public DbSet<Product> Products{ get; set;}
        public DbSet<CustomerProduct> CustomerProducts{ get; set; }
        public DbSet<DateActivity> DateActivities{ get; set; }
        public DbSet<DateActivityType> DateActivityTypes { get; set; }
        public DbSet<Payment> Payment { get; set; }
    }
}

