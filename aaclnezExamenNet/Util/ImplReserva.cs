using aaclnezExamenNet.Models;

namespace aaclnezExamenNet.Util
{
    /// <summary>
    /// Clase con metodos de el Objeto Reserva
    /// </summary>
    public class ImplReserva
    {

        /// <summary>
        /// Metodo que crea y devuelve una Reserva
        /// </summary>
        /// <returns></returns>
        public static Reserva crearReserva()
        {
            Reserva r1 = new Reserva();

            Console.WriteLine("Cual es la fecha de la reserva");
            r1.FechaReserva = Console.ReadLine();

            return r1;



        }
    }
}
