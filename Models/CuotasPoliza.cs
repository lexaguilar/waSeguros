using System;
using System.Collections.Generic;

#nullable disable

namespace waSeguros.Models
{
    public partial class CuotasPoliza
    {
        public int IdCuotaPoliza { get; set; }
        public int IdRecibo { get; set; }
        public int? NoCuota { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public decimal? MontoCuota { get; set; }
        public DateTime? FechaPago { get; set; }
        public decimal? MontoPagado { get; set; }
        public string Pagado { get; set; }

        public virtual Poliza IdReciboNavigation { get; set; }
    }
}
