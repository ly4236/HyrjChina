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
                new Category { Name="���"},
                new Category { Name="���ϼ�վ��"},
                new Category { Name="�������Ż�"},
                new Category { Name="Ԥ������"},
            };
            category.ForEach(s => context.Categorys.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();


            var product = new List<Product>
            {
                new Product {
                    Name = "�ֻ��ۺϹ���ϵͳ-��׼��-S10��[�Ź�]",
                    CategoryID = 1,
                    Description = "s",
                    Price = 1860,

                },
                new Product {
                    Name = "�ֻ��ۺ�Ӫҵϵͳ-������-Mϵ��",
                    CategoryID = 1,
                    Description = "1",
                    Price = 2980,
                },
                new Product {
                    Name = "�ֻ���ó��Ӫ֧��ϵͳ-������-E20ϵ��",
                    CategoryID = 1,
                    Description = "2",
                    Price = 23800,
                },
                new Product {
                    Name = "�ֻ��ۺϹ���ϵͳ-��׼��-S10��",
                    CategoryID = 1,
                    Description = "435",
                    Price = 2720,
                },
                new Product {
                    Name = "�ǹ���ó����ϵͳ-������-V20ϵ��",
                    CategoryID = 1,
                    Description = "3",
                    Price = 6480,
                },
                new Product {
                    Name = "�ֻ��ۺϹ���ϵͳ-������-Ver60ϵ��",
                    CategoryID = 1,
                    Description = "345",
                    Price = 2980,
                },
                new Product {
                    Name = "�ֻ���ó��Ӫ֧��ϵͳ-������E20ϵ��[�Ź�]",
                    CategoryID = 1,
                    Description = "543",
                    Price = 13800,
                },
                new Product {
                    Name = "��װ��������ϵͳ-ר����-Ver17ϵ��",
                    CategoryID = 1,
                    Description = "dsfsd",
                    Price = 1650,
                },
                new Product {
                      Name = "��������ɨ��ǹ",
                    CategoryID = 2,
                    Description = "���߾���100�ף����ϰ��",
                    Price = 650,
                },
                new Product {
                      Name = "��������Զ�̽���ƽ̨��5�û��� ",
                    CategoryID = 2,
                    Description = "�ʺ�ר�÷�����ϵͳ����Ӧ��",
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
                new User { Username="ly4236",Name = "����",Password = "123"}
            };

            user.ForEach(s => context.Users.AddOrUpdate(p => p.Username, s));
            context.SaveChanges();
        }
    }
}
