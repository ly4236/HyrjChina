using HyrjChina.Web.Entities.Customers;
using HyrjChina.Web.Services.Models;
using HyrjChina.Web.Services.Util;
using HyrjChina.Web.Services.Util.Pagings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HyrjChina.Web.Services.Customers
{

    public sealed class CustomerManageService : ServiceContext, ICustomerManageService
    {
        public PagedResult<CustomerManagePageItem> GetList(Paging paging)
        {
            var queryPageResult = new PagedResult<CustomerManagePageItem>
            {
                PageIndex = paging.PageIndex,
                PageSize = paging.PageSize,
            };

            var query = from Customer in DbContext.Customer
                        orderby Customer.CreateTime descending
                        where !Customer.Deleted
                        select new CustomerManagePageItem
                        {
                            Name = Customer.Name,
                            Nick = Customer.Nick,
                            IsEnable = Customer.Active,
                            CreateTime = Customer.CreateTime
                        };

            queryPageResult.SizeCount = query.Count();
            queryPageResult.Result = query.Skip(paging.PageIndex * paging.PageSize).Take(paging.PageSize).ToList();

            return queryPageResult;
        }

        public bool Create(Customer model)
        {
            DbContext.Customer.Add(model);
            return DbContext.SaveChanges() > 0;
        }

        public bool ExistsCustomer(string Name)
        {
            return DbContext.Customer.FirstOrDefault(p => p.Name == Name) != null;
        }

        public Customer Get(string Name = "")
        {
            return DbContext.Customer.FirstOrDefault(p => p.Name == Name);
        }

        public bool Edit(Customer model)
        {
            DbContext.Entry(model).State = EntityState.Modified;
            return DbContext.SaveChanges() > 0;
        }

        public bool Delete(string Name)
        {
            var category = DbContext.Customer.Where(p => p.Name == Name).FirstOrDefault();
            category.Deleted = true;
            return DbContext.SaveChanges() > 0;
        }
    }
}