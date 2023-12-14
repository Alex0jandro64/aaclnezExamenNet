using System;
using System.Collections.Generic;

namespace aaclnezExamenNet.Models;

/// <summary>
/// Clase del objeto Vajilla
/// </summary>
public partial class Vajilla
{
    public int IdVajilla { get; set; }

    public int? CatidadElemento { get; set; }

    public string? CodigoElemento { get; set; }

    public string? DescripcionElemento { get; set; }

    public string? NombreElemento { get; set; }

    public virtual ICollection<RelVajillaReserva> RelVajillaReservas { get; set; } = new List<RelVajillaReserva>();
}
