using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DetallePolizas.Models.DB;

public partial class CoberturasPoliza
{
    public int IdCoberturasPoliza { get; set; }

    public int IdPoliza { get; set; }

    public int IdCobertura { get; set; }

    [JsonIgnore]
    public virtual Poliza? IdPolizaNavigation { get; set; }
}
