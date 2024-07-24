

namespace Mini_MarketX.Data.Exceptions
{
    public class CargadeDatosException : Exception
    {
        public CargadeDatosException(string message) { }

        public CargadeDatosException(string? message, Exception? innerException) : base(message, innerException)
        {

        }
    }
}
