using aaclnezExamenNet.Models;

namespace aaclnezExamenNet.Services
{
    /// <summary>
    /// Interfaz de la clase CrudVajillaService
    /// </summary>
    public interface InterfazCrudVajillaService
    {
        public void Insertar(Vajilla vajilla);
        public List<Vajilla> ObtenerVajillas();
    }
}
