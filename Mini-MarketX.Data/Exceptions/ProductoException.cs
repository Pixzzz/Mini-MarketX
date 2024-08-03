

namespace Mini_MarketX.Data.Exceptions
{
    public class ProductoNullException : Exception
    {
        public ProductoNullException(string message) : base(message)
        {
            // logica para guardar el log del error y enviar la notificacion.
        }
    }
}