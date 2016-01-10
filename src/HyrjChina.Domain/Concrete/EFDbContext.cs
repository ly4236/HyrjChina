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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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
