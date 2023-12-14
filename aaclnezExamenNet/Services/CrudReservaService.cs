using aaclnezExamenNet.Models;

namespace aaclnezExamenNet.Services
{
    /// <summary>
    /// Clase que contiene los metodos del crud de el Objeto Reserva
    /// </summary>
    public class CrudReservaService : InterfazCrudReservaService
    {


        private readonly ExaDosContext _contexto;
        public CrudReservaService(ExaDosContext dbContext)
        {
            _contexto = dbContext;
        }

        /// <summary>
        /// Metodo que Inserta en la base de datos un objeto Reserva
        /// </summary>
        /// <param name="reserva"></param>
        public void Insertar(Reserva reserva)
        {
            _contexto.Reservas.Add(reserva);
            _contexto.SaveChanges();
        }
    }
}
