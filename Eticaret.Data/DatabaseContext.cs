
using System.Reflection;
using Eticaret.Core.Entities;
using Eticaret.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Eticaret.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //veri tabanı bağlantı alanı
        {
            optionsBuilder.UseSqlServer(
                
@"Server=(localdb)\MSSQLLocalDB; 
Database=EticaretDb; 
Trusted_Connection=True; 
TrustServerCertificate=True;");

            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning)); //model değişikliklerini yoksay

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly
                (Assembly.GetExecutingAssembly()); //sistem çalışınca otomatik olarak çalışan dll içinden bul 
            base.OnModelCreating(modelBuilder);
        }
    }
}
