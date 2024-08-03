namespace Mini_MarketX.Data.Exceptions
{
    public class ReporteDuplicadoException : Exception
    {
        public ReporteDuplicadoException(string message) : base(message)
        {
            // x logica para guardar el log del error y enviar la notificacion
        }
    }
}
