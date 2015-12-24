using HyrjChina.Web.Entities.Customers;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HyrjChina.Web.Entities
{
    /// <summary>
    /// 默认数据上下文
    /// </summary>
    public class DefaultDbContext : DbContext
    {
        /// <summary>
        /// 用户表
        /// </summary>
        public DbSet<Customer> Customer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //移除复数表名
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}