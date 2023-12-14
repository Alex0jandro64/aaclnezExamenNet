using aaclnezExamenNet.Models;
using System.Security.Cryptography.Xml;

namespace aaclnezExamenNet.Util
{
    /// <summary>
    /// Clase con metodos de el objeto Vajilla
    /// </summary>
    public class ImplVajilla
    {

        /// <summary>
        /// Metodo que crear un Objeto Vajilla 
        /// </summary>
        /// <returns></returns>
        static public Vajilla crearVajilla()
        {
            Vajilla v1 = new Vajilla();


            Console.WriteLine("Cual es el Nombre de la Vajilla:");
            v1.NombreElemento = Console.ReadLine();
            Console.WriteLine("Cual es la descripcion de la Vajilla");
            v1.DescripcionElemento = Console.ReadLine();
            Console.WriteLine("Cual es la cantidad de las Vajillas");
            int cantidad = 0;
            try
            {
                do
                {
                    cantidad = int.Parse(Console.ReadLine());
                    if (cantidad < 0)
                    {
                        Console.WriteLine("La cantidad no puede ser menor que 0");
                    }
                } while (cantidad < 0);
            }
            catch (Exception)
            {
                Console.WriteLine("Error al añadir el numero");
                throw new Exception();
            }

            v1.CodigoElemento = "Elem-" + v1.NombreElemento;
            return v1;
        }

        /// <summary>
        /// Metodo que imprime una lista de Vajillas por consola
        /// </summary>
        /// <param name="listaVajillas"></param>
        public static void imprimirListaVajilla(List<Vajilla> listaVajillas)
        {
            foreach (var vajilla in listaVajillas)
            {
                Console.WriteLine("{0}, {1}, {2}", vajilla.CodigoElemento, vajilla.NombreElemento, vajilla.CatidadElemento);
            }
        }

        /// <summary>
        /// Metodo que pide y devuelve un codigo de Vajilla
        /// </summary>
        /// <returns></returns>
        public static string pideCodigoVajillaReservar()
        {
            Console.WriteLine("Cual es el codigo de la Vajilla a reservar");
            return Console.ReadLine();
        }

        /// <summary>
        /// Metodo que pide y devuelve la cantidad de vajilla a reservar
        /// </summary>
        /// <returns></returns>
        public static int pideCantidadReservar()
        {
            int cantidad = -1;
            try
            {
                Console.WriteLine("Cual es la cantidad de Vajilla a reservar");
                do
                {
                    cantidad = int.Parse(Console.ReadLine());
                    if (cantidad < 0)
                    {
                        Console.WriteLine("La cantidad no puede ser menos que 0");
                    }
                } while (cantidad < 0);
            }
            catch (Exception)
            {
                Console.WriteLine("Error al capturar la cantidad");
            }

            return cantidad;


        }

    }
}
