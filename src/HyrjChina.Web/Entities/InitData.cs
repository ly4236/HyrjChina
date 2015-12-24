using HyrjChina.Web.Entities.Customers;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace HyrjChina.Web.Entities
{
    /// <summary>
    /// 数据库初始化种子
    /// </summary>
    public sealed class InitData : CreateDatabaseIfNotExists<DefaultDbContext>
    {
        protected override void Seed(DefaultDbContext context)
        {
            //默认用户
            new List<Customer>
            {
                new Customer{
                Name="admin",
                Password= "e10adc3949ba59abbe56e057f20f883e",
                CreateTime = DateTime.Now,
                Active = true,
                Deleted =false,
                Nick = "管理员"}
            }.ForEach(m => context.Customer.Add(m));
        }
    }
}