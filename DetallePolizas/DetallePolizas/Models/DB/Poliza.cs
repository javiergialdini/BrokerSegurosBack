using System;
using System.Collections.Generic;

namespace DetallePolizas.Models.DB;

public partial class Poliza
{
    public int IdPoliza { get; set; }

    public string NomPoliza { get; set; } = null!;

    public int MontoAsegurado { get; set; }

    public virtual ICollection<CoberturasPoliza> CoberturasPolizas { get; } = new List<CoberturasPoliza>();
}
