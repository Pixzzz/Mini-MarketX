using Moq;
using Mini_MarketX.Data.Context;
using Mini_MarketX.Data.Repositories.Mocks;
using Mini_MarketX.Data.Entities;
using Mini_MarketX.Data.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Mini_MarketX.Test
{
    public class UnitTestProductoMMXRepository
    {
        [Fact]
        public void Actualizar_ProductoIsNull()
        {
            // Arrange //
            var context = new Mini_MarketXContext();
            var repository = new MockProductoMMXRepository(context);



            // Act
            Producto producto = null;

            // Assert //
            Assert.Throws<ProductoNullException>(() => repository.Actualizar(producto));
        }




        [Fact]
        public void Actualizar_Producto_Not_Exists()
        {
            // Arrange //
            var context = new Mini_MarketXContext();
            var repository = new MockProductoMMXRepository(context);



            // Act
            Producto producto = new Producto()
            {

                ProductoId = 8

            };




            Assert.Throws<ProductoNotExistsException>(() => repository.Actualizar(producto));
        }

        [Fact]
        public void Ingresar_Producto_Duplicado()
        {
            // Arrange //
            var context = new Mini_MarketXContext();
            var repository = new MockProductoMMXRepository(context);



            // Act
            Producto producto = new Producto()
            {

                ProductoId = 1,
                Nombre = "Producto1"

            };

            Assert.Throws<ProductoDuplicadoException>(() => repository.Agregar(producto));
        }



        [Fact]
        public void ObtenerporId_ReturnProducto_WhenProductoExists()
        {
            // Arrange //
            var context = new Mini_MarketXContext();
            var repository = new MockProductoMMXRepository(context);



            // Act

            int productoId = 1;

            var producto = repository.ObtenerporId(productoId);


            // Assert //
            Assert.NotNull(producto);
            var datos = Assert.IsType<Producto>(producto);

        }



        [Fact]
        public void TraerTodos_ReturnListaProducto_ifProductoExists()
        {
            // Arrange //
            var context = new Mini_MarketXContext();
            var repository = new MockProductoMMXRepository(context);



            // Act

            var producto = repository.TraerTodos();


            // Assert //
            Assert.NotNull(producto);
            Assert.IsType<List<Producto>>(producto);
            Assert.True(producto.Count > 0);

        }

    }
}