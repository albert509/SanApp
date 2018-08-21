using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SanApp.Models;

namespace SanApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<San> San { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Participante> Participantes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
