using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AustriaSkiResorts.Models
{
    public class resortContext : DbContext
    {
        public resortContext (DbContextOptions<resortContext> options)
            : base(options)
        {
        }

        public DbSet<AustriaSkiResorts.Models.resort> resort { get; set; }
    }
}
