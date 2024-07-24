using System.Diagnostics;

namespace Mini_MarketX.Data.Exceptions
{
    public class ReporteNullException : Exception
    {
        public ReporteNullException(string message) : base(message)
        {
            // x logica para guardar el log del error y enviar la notificacion.
        }
    }
}
