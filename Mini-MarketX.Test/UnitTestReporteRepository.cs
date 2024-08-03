using Mini_MarketX.Data.Context;
using Mini_MarketX.Data.Entities;
using Mini_MarketX.Data.Exceptions;
using Mini_MarketX.Data.Repositories.Mocks;
using Moq;
namespace Mini_MarketX.Test
{
    public class UnitTestReporteRepository
    {

        [Fact]
        public void Actualizar_ReporteIsNull()
        {
            // Arrange //

            var context = new Mini_MarketXContext();
            var repository = new MockReporteRepository(context);


            // Act  //

            Reporte reporte = null;

            // Assert //
            Assert.Throws<ReporteNullException>(() => repository.Actualizar(reporte));
           
        }

        [Fact]
        public void Actualizar_Reporte_Not_Exists()
        {
            // Arrange //

            var context = new Mini_MarketXContext();
            var repository = new MockReporteRepository(context);


            // Act  //

            Reporte reporte = new Reporte()
            {
                ReporteId = 8, 
            };

            // Assert //

            Assert.Throws<ReporteNotExistsExeption>(() => repository.Actualizar(reporte));

        }

        [Fact]
        public void Remover_Reporte_Is_Null()
        {
            // Arrange //

            var context = new Mini_MarketXContext();
            var repository = new MockReporteRepository(context);


            // Act  //

            Reporte reporte = null;

            // Assert //

            Assert.Throws<ReporteNullException>(() => repository.Remover(reporte));

        }

        [Fact]
        public void Agregar_Reporte_Duplicado()
        {
            // Arrange //

            var context = new Mini_MarketXContext();
            var repository = new MockReporteRepository(context);


            // Act  //

            Reporte reporte1 = null;

            Reporte reporte2 = new Reporte()
            {
                ReporteId = 2,
                AreaId = 2
            };

            // Assert //

            Assert.Throws<ReporteNullException>(() => repository.Agregar(reporte1));
            Assert.Throws<ReporteDuplicadoException>(() => repository.Agregar(reporte2));

        }

        [Fact]
        public void ObtenerPorId_ReturnReporte_WhenReporteExist()
        {
            // Arrange //

            var context = new Mini_MarketXContext();
            var repository = new MockReporteRepository(context);


            // Act  //

            int reporteId = 3;
            int areaId = 3;
            var reporte = repository.ObtenerPorId(reporteId);

            // Assert //

            Assert.NotNull(reporte);
            var datos = Assert.IsType<Reporte>(reporte);

        }
    }
}