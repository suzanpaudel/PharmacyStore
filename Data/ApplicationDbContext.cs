using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using PharmacyStore.Models;

namespace PharmacyStore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PharmacyStore.Models.Category> Category { get; set; }
        public DbSet<PharmacyStore.Models.Product> Product { get; set; }
        public DbSet<PharmacyStore.Models.ProductStock> ProductStock { get; set; }
        public DbSet<PharmacyStore.Models.Customer> Customer { get; set; }
        public DbSet<PharmacyStore.Models.Purchase> Purchase { get; set; }
        public DbSet<PharmacyStore.Models.PurchaseDetail> PurchaseDetail { get; set; }
        public DbSet<PharmacyStore.Models.Sales> Sales { get; set; }
        public DbSet<PharmacyStore.Models.SalesDetail> SalesDetail { get; set; }
    }
}
