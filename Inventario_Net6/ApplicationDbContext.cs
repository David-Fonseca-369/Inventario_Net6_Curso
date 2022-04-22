﻿using Inventario_Net6.Entidades;
using Inventario_Net6.Mapeo;
using Microsoft.EntityFrameworkCore;

namespace Inventario_Net6
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RolMap());
        }

        public DbSet<Rol> Roles { get; set; }
    }
}
