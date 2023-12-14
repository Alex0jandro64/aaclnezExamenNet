using aaclnezExamenNet.Models;

namespace aaclnezExamenNet.Services
{
    /// <summary>
    /// Clase que contiene los metodos Crud de el objeto vajilla
    /// </summary>
    public class CrudVajillaService : InterfazCrudVajillaService
    {

        private readonly ExaDosContext _contexto;
        public CrudVajillaService(ExaDosContext dbContext)
        {
            _contexto = dbContext;
        }

        /// <summary>
        /// Metodo que Inserta un objeto vajilla en la base de datos
        /// </summary>
        /// <param name="vajilla"></param>
        public void Insertar(Vajilla vajilla)
        {
            _contexto.Vajillas.Add(vajilla);
            _contexto.SaveChanges();
        }

        /// <summary>
        /// Metodo que devuelve una lista de objeto de Vajitas de la base de datos
        /// </summary>
        /// <returns></returns>
        public List<Vajilla> ObtenerVajillas()
        {
            return _contexto.Vajillas.ToList();
        }

    }
}
