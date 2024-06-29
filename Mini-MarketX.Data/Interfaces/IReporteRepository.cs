

using Mini_MarketX.Data.Entities;

namespace Mini_MarketX.Data.Interfaces
{
    public interface IReporteRepository
    {
        void Agregar(Reporte reporte);
        void Actualizar(Reporte reporte);
        void Remover(Reporte reporte);
        List<Reporte> TraerTodos();
        Reporte ObtenerPorId(int reporteId);
    }
}
