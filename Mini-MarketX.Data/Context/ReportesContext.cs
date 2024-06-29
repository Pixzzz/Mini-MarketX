

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Mini_MarketX.Data.Entities;

namespace Mini_MarketX.Data.Context
{
    public class ReportesContext : DbContext
    {
        public ReportesContext(DbContextOptions<ReportesContext> options) : base(options) 
        {
        
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("ReporteInventario");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Reporte> Reportes { get; set; }
    }
}
