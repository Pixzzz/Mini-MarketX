namespace Mini_MarketX.Data.Exceptions
{
    public class ReporteNotExistsExeption : Exception
    {
        public ReporteNotExistsExeption(string message) : base(message)
        {
            // x logica para guardar el log del error y enviar la notificacion.
        }
    }
}
