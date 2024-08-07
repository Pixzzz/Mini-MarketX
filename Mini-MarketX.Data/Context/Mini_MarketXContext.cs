﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mini_MarketX.Data.Entities;

namespace Mini_MarketX.Data.Context
{
    public class Mini_MarketXContext : DbContext
    {

        public Mini_MarketXContext(DbContextOptions<Mini_MarketXContext> options) : base(options)
        {

        }

        public Mini_MarketXContext()
        {

        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("MiniMarketXDB");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Reporte>? Reportes { get; set; }
        public DbSet<Producto>? Productos { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
