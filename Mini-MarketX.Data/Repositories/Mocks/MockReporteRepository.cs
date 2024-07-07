using Mini_MarketX.Data.Context;
using Mini_MarketX.Data.Entities;
using Mini_MarketX.Data.Exceptions;
using Mini_MarketX.Data.Interfaces;
namespace Mini_MarketX.Data.Repositories.Mocks
{
    public class MockReporteRepository : IReporteRepository
    {
        private readonly Mini_MarketXContext context;

        public MockReporteRepository(Mini_MarketXContext context)
        {
            this.context = context;
            this.CargarDatos();
        }
        public void Actualizar(Reporte reporte)
        {
            if (EsReporteNull(reporte))
                throw new ReporteNullException("El objeto reporte no debe ser nulo");

            Reporte reporteToUpdate = this.context.Reportes.Find(reporte.ReporteId);
            if (reporteToUpdate is null)
                throw new ReporteNotExistsExeption("El reporte no se encuentra registrado");

            reporteToUpdate.ReporteId = reporte.ReporteId;
            reporteToUpdate.Nombre = reporte.Nombre;
            reporteToUpdate.Descripcion = reporte.Descripcion;
            reporteToUpdate.FechaCreacion = reporte.FechaCreacion;

            this.context.Reportes.Update(reporteToUpdate);
            this.context.SaveChanges(); 


        }

        public void Agregar(Reporte reporte)
        {
            if (EsReporteNull(reporte))
                throw new ReporteNullException("El objeto reporte no debe ser nulo");

            if (ExisteReporte(reporte.ReporteId, reporte.AreaId)) 
                throw new ReporteDuplicadoException($"Este reporte{reporte.ReporteId} para esta area: {reporte.AreaId} se encuentra registrado.");

            Reporte reporteToAdd = new Reporte()
            {
                AreaId = reporte.AreaId,
                ReporteId = reporte.ReporteId,
                Nombre = reporte.Nombre,
                Descripcion = reporte.Descripcion,
                FechaCreacion = reporte.FechaCreacion
            };

            this.context.Reportes.Add(reporteToAdd);
            this.context.SaveChanges();
           
        }

        public Reporte ObtenerPorId(int reporteId)
        {
            return this.context.Reportes.Find(reporteId);
        }

        public void Remover(Reporte reporte)
        {
            if (EsReporteNull(reporte))
            {
                throw new ReporteNullException("El objeto reporte no debe de ser nulo.");
            
                Reporte reporteToRemove = this.context.Reportes.Find(reporte.ReporteId);

                if(reporteToRemove is null) 
                {
                    throw new ReporteNotExistsExeption("El  objeto reporte no se encuentra registrado.");
                }

                this.context.Reportes.Remove(reporteToRemove);
                this.context.SaveChanges();
            }
        }

        public List<Reporte> TraerTodos()
        {
            return this.context.Reportes.ToList();
        }

        private void CargarDatos() 
        {

            if (!this.context.Reportes.Any()) 
            {
                List<Reporte> reportes = new List<Reporte>()
            {
                new Reporte()
                {
                    AreaId = 1,
                    ReporteId = 1,
                Nombre = "Reporte 1",
                Descripcion = "Este es el primer reporte",
                FechaCreacion = DateTime.Now
                },

                new Reporte()
                {
                    AreaId = 2,
                     ReporteId = 2,
                Nombre = "Reporte 2",
                Descripcion = "Este es el segundo reporte",
                FechaCreacion = DateTime.Now
                },

                new Reporte()
                {
                    AreaId = 3,
                     ReporteId = 3,
                Nombre = "Reporte 3",
                Descripcion = "Este es el tercerr reporte",
                FechaCreacion = DateTime.Now
                },

                new Reporte()
                {
                    AreaId = 4,
                    ReporteId = 4,
                    Nombre = "Reporte 4",
                    Descripcion = "Este es el cuarto reporte",
                    FechaCreacion = DateTime.Now
                }
            };

                this.context.Reportes.AddRange(reportes);
                this.context.SaveChanges();
            }

           
        }

        private bool EsReporteNull(Reporte reporte)
        {
            bool result = false;
            if (reporte == null) 
            return true;
            return result;
        }

        private bool ExisteReporte(int reporteId, int areaId)
        {
            return this.context.Reportes.Any(cd => cd.ReporteId == reporteId && cd.AreaId == areaId);
        }

        private void LimpiarDatos(List<Reporte> reportes)
        {
            this.context.Reportes.RemoveRange(reportes);
            this.context.SaveChanges();
        }
    }
}
