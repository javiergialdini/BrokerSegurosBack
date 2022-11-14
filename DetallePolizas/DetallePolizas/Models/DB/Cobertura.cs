using System;
using System.Collections.Generic;

namespace DetallePolizas.Models.DB;

public partial class Cobertura
{
    public int IdCobertura { get; set; }

    public string CodCobertura { get; set; } = null!;

    public string NomCobertura { get; set; } = null!;
}
