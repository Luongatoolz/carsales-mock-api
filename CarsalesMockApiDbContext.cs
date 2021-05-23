using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsalesMockApi
{
    public class CarsalesMockApiDbContext : DbContext
    {
        public CarsalesMockApiDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Subscriber> Subscribers { get; set; }
    }
}
