using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderTrack.Models;

namespace OrderTrack.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
    }
}