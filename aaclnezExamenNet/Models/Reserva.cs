using System;
using System.Collections.Generic;

namespace aaclnezExamenNet.Models;

/// <summary>
/// Clase del Objeto Reserva
/// </summary>
public partial class Reserva
{
    public int IdReserva { get; set; }

    public string? FechaReserva { get; set; }

    public virtual ICollection<RelVajillaReserva> RelVajillaReservas { get; set; } = new List<RelVajillaReserva>();
}
