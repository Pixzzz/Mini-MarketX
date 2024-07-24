

using Mini_MarketX.Data.Entities;

namespace Mini_MarketX.Data.Interfaces
{
    public interface IProductoMMXRepository
    {
        void Agregar(Producto producto);

        void Eliminar(Producto producto);

        void Actualizar(Producto producto);

        List<Producto> TraerTodos();

        Producto ObtenerporId(int ProductoId);
    }
}

