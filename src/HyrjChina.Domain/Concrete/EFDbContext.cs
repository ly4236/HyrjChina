using HyrjChina.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace HyrjChina.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAddress>().HasKey(t => new { t.AddressId, t.UserId });
            //modelBuilder.Entity<Order>()
            //.HasRequired(m => m.Address)
            //.WithMany(t => t.Orders)
            //.HasForeignKey(m => m.AddressId)
            //.WillCascadeOnDelete(false);

            modelBuilder.Entity<Address>()
                .HasRequired(u => u.Province)
                .WithMany(d => d.ProvinceAddresses)
               .HasForeignKey(c => c.ProvinceId)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<Address>()
                .HasRequired(u => u.City)
                .WithMany(d => d.CityAddresses)
               .HasForeignKey(c => c.CityId)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<Address>()
                .HasRequired(u => u.Town)
                .WithMany(d => d.TownAddresses)
               .HasForeignKey(c => c.TownId)
               .WillCascadeOnDelete(false);




            //        base.OnModelCreating(modelBuilder);
            //        modelBuilder.Types<Customer>()
            //        .Configure(c =>
            //        {
            //            c.HasKey(cust => cust.CustomerId);

            //            c.Property(cust => cust.CustomerId)
            //.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //            c.Property(cust => cust.Name)
            // .HasMaxLength(50);
            //            c.Property(cust => cust.Company)
            // .HasMaxLength(50);
            //            c.Property(cust => cust.ContactTitle)
            // .HasMaxLength(50);
            //            c.ToTable("Customer", "Chapter10");
            //        });
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
        }

    }

}
