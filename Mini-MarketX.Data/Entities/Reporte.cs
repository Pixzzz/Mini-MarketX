namespace Mini_MarketX.Data.Entities
{
    public class Reporte
    {
        public int AreaId;
        public int ReporteId { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}
