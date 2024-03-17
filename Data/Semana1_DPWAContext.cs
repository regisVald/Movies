using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Semana1_DPWA.Models;

namespace Semana1_DPWA.Data
{
    public class Semana1_DPWAContext : DbContext
    {
        public Semana1_DPWAContext (DbContextOptions<Semana1_DPWAContext> options)
            : base(options)
        {
        }

        public DbSet<Semana1_DPWA.Models.Pelicula> Pelicula { get; set; } = default!;
    }
}
