using aaclnezExamenNet.Models;

namespace aaclnezExamenNet.Services
{
    /// <summary>
    /// Clase con los metodos crud de la relacion entre Vajilla y Reserva
    /// </summary>
    public class CrudRelVajillaReservaService : InterfazRelVajillaReserva
    {
        private readonly ExaDosContext _contexto;
        public CrudRelVajillaReservaService(ExaDosContext dbContext)
        {
            _contexto = dbContext;
        }

        public void Insertar(RelVajillaReserva relVajillaReserva)
        {
            _contexto.RelVajillaReservas.Add(relVajillaReserva);
            _contexto.SaveChanges();
        }
    }
}
