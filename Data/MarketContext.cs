using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VisionMVC.Models;

namespace VisionMVC.Data
{
    public class MarketContext : DbContext
    {
        public MarketContext(DbContextOptions<MarketContext> options) : base(options)
        { 
            
        } 
        public DbSet<Product> Product { get; set; }
    }
}
