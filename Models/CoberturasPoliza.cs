using System;
using System.Collections.Generic;

#nullable disable

namespace waSeguros.Models
{
    public partial class CoberturasPoliza
    {
        public int CodCobertura { get; set; }
        public int IdRecibo { get; set; }
        public decimal? MontoSumaAsegurada { get; set; }
        public decimal? MontoPrima { get; set; }
        public string Isuma { get; set; }

        public virtual Poliza IdReciboNavigation { get; set; }
    }
}
