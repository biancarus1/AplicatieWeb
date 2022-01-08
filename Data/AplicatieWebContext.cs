using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AplicatieWeb.Models;

namespace AplicatieWeb.Data
{
    public class AplicatieWebContext : DbContext
    {
        public AplicatieWebContext (DbContextOptions<AplicatieWebContext> options)
            : base(options)
        {
        }

        public DbSet<AplicatieWeb.Models.Appointment> Appointment { get; set; }

        public DbSet<AplicatieWeb.Models.Hairstylist> Hairstylist { get; set; }

        internal object Include(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        public DbSet<AplicatieWeb.Models.Service> Service { get; set; }
    }
}
