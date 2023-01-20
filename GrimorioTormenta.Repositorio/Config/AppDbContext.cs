using GrimorioTormenta.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimorioTormenta.Repositorio.Config
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ) : base(options)
        {
        
        }

        public DbSet<GrupoModel> Grupos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GrupoModel>().Property(p=>p.Nome).IsRequired().HasMaxLength(50);
        }
    }
}
