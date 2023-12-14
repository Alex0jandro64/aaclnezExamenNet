using aaclnezExamenNet.Models;
using aaclnezExamenNet.Services;
using aaclnezExamenNet.Util;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace aaclnezExamenNet.Controllers
{
    /// <summary>
    /// Clase Controladora Principal
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly InterfazCrudVajillaService _servicioVajilla;
        private readonly InterfazCrudReservaService _servicioReserva;
        private readonly InterfazRelVajillaReserva _servicioRelVajillaReserva;

        public HomeController(ILogger<HomeController> logger,InterfazRelVajillaReserva servicioVajillaReserva, InterfazCrudVajillaService servicioVajilla, InterfazCrudReservaService servicioReserva)
        {
            _logger = logger;
            _servicioVajilla = servicioVajilla;
            _servicioReserva = servicioReserva;
            _servicioRelVajillaReserva = servicioVajillaReserva;
        }

        public IActionResult Index()
        {
            //Declaraciones
            List<Vajilla>listaVajillasInsertadas = new List<Vajilla>();
            List<Vajilla>listaVajillasObtenidas = new List<Vajilla>();
            List<Reserva>listaReservasInsertadas = new List<Reserva>();
            Vajilla v1 = new Vajilla();
            bool cerrar = false;
            //Programa, no se cierra pero solo habria que poner un case 4 que cambien cerrar a true
            do
            {
                Utilidades.menuPrincipal();
                int opcion = 0;
                try
                {
                    opcion = int.Parse(Console.ReadLine());
                }catch(Exception)
                {
                    Console.WriteLine("Error al capturar el numero");
                }
                
                switch (opcion)
                {
                    //En caso 1 Pido e Inserto el objeto en la base de datos
                    case 1:
                        try
                        {
                            listaVajillasInsertadas.Add(ImplVajilla.crearVajilla());
                            _servicioVajilla.Insertar(listaVajillasInsertadas[listaVajillasInsertadas.Count()-1]);
                        }
                        catch (Exception)
                        {
                        }
                        break;

                        //En caso 2 get de todos los objetos, se pasan a lista dto y se imprime por pantalla
                    case 2:
                        try
                        {
                            listaVajillasObtenidas = _servicioVajilla.ObtenerVajillas();
                            ImplVajilla.imprimirListaVajilla(listaVajillasObtenidas);
                        }
                        catch
                        {
                            Console.WriteLine("Error al mostrar las vajillas");
                        }
                        break;

                        //En caso 3 Pido la fecha de la reserva que yo uso String, y lo inserto en la base de datos
                        //Pido el codigo de elemento y lo busco en la lista de objetos que me guardo al hacer el get
                        //Pido la cantidad que va a reservar y lo añado todo al objerto RelVajillaReserva y lo inserto en la base de datos
                    case 3:
                        try
                        {
                            bool encontrado = false;
                            listaReservasInsertadas.Add(ImplReserva.crearReserva());
                            _servicioReserva.Insertar(listaReservasInsertadas[listaReservasInsertadas.Count() - 1]);
                            String codigoVajilla = ImplVajilla.pideCodigoVajillaReservar();
                            foreach (var item in listaVajillasObtenidas)
                            {   
                                if(item.CodigoElemento== codigoVajilla)
                                {
                                    v1 = item; 
                                    encontrado= true;
                                    break;
                                }
                            }
                            if (!encontrado)
                            {
                                Console.WriteLine("No se a encontrado esa vajilla");
                                break;
                            }
                            int cantidad = ImplVajilla.pideCantidadReservar();
                            RelVajillaReserva rel1 = new RelVajillaReserva();
                            rel1.Cantidad= cantidad;
                            rel1.ReservaIdReserva = listaReservasInsertadas[listaReservasInsertadas.Count() - 1].IdReserva;
                            rel1.VajillaIdVajilla = v1.IdVajilla;
                            _servicioRelVajillaReserva.Insertar(rel1);

                        }
                        catch(Exception)
                        {
                            Console.WriteLine("Error al Crear la Reserva");
                        }
                        break;

                }

            } while (!cerrar);













            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}