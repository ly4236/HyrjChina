namespace HyrjChina.Domain.Migrations
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HyrjChina.Domain.Concrete.EFDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HyrjChina.Domain.Concrete.EFDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var category = new List<Category>
            {
                new Category { Name="软件"},
                new Category { Name="辅料及站点"},
                new Category { Name="促销及优惠"},
                new Category { Name="预付定金"},
            };
            category.ForEach(s => context.Categorys.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();


            var product = new List<Product>
            {
                new Product {
                    Name = "手机综合管理系统-标准版-S10版[团购]",
                    CategoryID = 1,
                    Description = "s",
                    Price = 1860,

                },
                new Product {
                    Name = "手机综合营业系统-分销版-M系列",
                    CategoryID = 1,
                    Description = "1",
                    Price = 2980,
                },
                new Product {
                    Name = "手机商贸运营支撑系统-连锁版-E20系列",
                    CategoryID = 1,
                    Description = "2",
                    Price = 23800,
                },
                new Product {
                    Name = "手机综合管理系统-标准版-S10版",
                    CategoryID = 1,
                    Description = "435",
                    Price = 2720,
                },
                new Product {
                    Name = "智工工贸管理系统-生产版-V20系列",
                    CategoryID = 1,
                    Description = "3",
                    Price = 6480,
                },
                new Product {
                    Name = "手机综合管理系统-分销版-Ver60系列",
                    CategoryID = 1,
                    Description = "345",
                    Price = 2980,
                },
                new Product {
                    Name = "手机商贸运营支撑系统-连锁版E20系列[团购]",
                    CategoryID = 1,
                    Description = "543",
                    Price = 13800,
                },
                new Product {
                    Name = "衣装售卖管理系统-专卖版-Ver17系列",
                    CategoryID = 1,
                    Description = "dsfsd",
                    Price = 1650,
                },
                new Product {
                      Name = "激光无线扫码枪",
                    CategoryID = 2,
                    Description = "无线距离100米（无障碍物）",
                    Price = 650,
                },
                new Product {
                      Name = "鼎智易联远程接入平台【5用户】 ",
                    CategoryID = 2,
                    Description = "适合专用服务器系统部署应用",
                    Price = 5930,
                }

            };
            product.ForEach(s => context.Products.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();


            var customer = new List<Customer>
            {
                new Customer { Name = "ly4236"},
            };

            customer.ForEach(s => context.Customers.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var user = new List<User>
            {
                new User { Username="ly4236",Name = "李杨",Password = "123"}
            };

            user.ForEach(s => context.Users.AddOrUpdate(p => p.Username, s));
            context.SaveChanges();
        }
    }
}
