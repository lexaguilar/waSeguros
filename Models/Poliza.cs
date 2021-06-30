using System;
using System.Collections.Generic;

#nullable disable

namespace waSeguros.Models
{
    public partial class Poliza
    {
        public Poliza()
        {
            CoberturasPolizas = new HashSet<CoberturasPoliza>();
            CuotasPolizas = new HashSet<CuotasPoliza>();
        }

        public int IdRecibo { get; set; }
        public int? IdContrantante { get; set; }
        public string NumeroPoliza { get; set; }
        public DateTime? FechaVenta { get; set; }
        public int? CodRamo { get; set; }
        public DateTime? VigenciaDesde { get; set; }
        public DateTime? VigenciaHasta { get; set; }
        public int? CodMoneda { get; set; }
        public decimal? TotalSumaAsegurada { get; set; }
        public decimal? TotalPrima { get; set; }
        public decimal? PDerechoEmision { get; set; }
        public decimal? MontoDerechoEmision { get; set; }
        public decimal? PImpuesto { get; set; }
        public decimal? MontoImpuesto { get; set; }
        public decimal? MontoTotal { get; set; }
        public decimal? MontoPagado { get; set; }
        public decimal? MontoPendiente { get; set; }
        public int? CantidadCuotas { get; set; }
        public string Estado { get; set; }

        public virtual CatMonedum CodMonedaNavigation { get; set; }
        public virtual CatRamo CodRamoNavigation { get; set; }
        public virtual Cliente IdContrantanteNavigation { get; set; }
        public virtual ICollection<CoberturasPoliza> CoberturasPolizas { get; set; }
        public virtual ICollection<CuotasPoliza> CuotasPolizas { get; set; }
    }
}
