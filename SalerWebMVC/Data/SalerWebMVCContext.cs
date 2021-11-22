using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalerWebMVC.Models;

namespace SalerWebMVC.Data
{
    public class SalerWebMVCContext : DbContext
    {
        public SalerWebMVCContext (DbContextOptions<SalerWebMVCContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Saller> Saller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
    }
}
