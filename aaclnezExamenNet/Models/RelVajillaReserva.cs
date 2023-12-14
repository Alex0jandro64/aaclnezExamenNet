using System;
using System.Collections.Generic;

namespace aaclnezExamenNet.Models;

/// <summary>
/// Clase de la relacion entre los objetos Vajilla y Reserva
/// </summary>
public partial class RelVajillaReserva
{
    public int IdRelVajillaReserva { get; set; }

    public int? Cantidad { get; set; }

    public int? ReservaIdReserva { get; set; }

    public int? VajillaIdVajilla { get; set; }

    public virtual Reserva? ReservaIdReservaNavigation { get; set; }

    public virtual Vajilla? VajillaIdVajillaNavigation { get; set; }
}
