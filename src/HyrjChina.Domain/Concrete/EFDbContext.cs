﻿using HyrjChina.Domain.Entities;
using System.Data.Entity;

namespace HyrjChina.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }

}
