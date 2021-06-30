using System;
using System.Collections.Generic;

#nullable disable

namespace waSeguros.Models
{
    public partial class CatRamo
    {
        public CatRamo()
        {
            CatCoberturas = new HashSet<CatCobertura>();
            Polizas = new HashSet<Poliza>();
        }

        public int CodRamo { get; set; }
        public string Xramo { get; set; }
        public string Abreviatura { get; set; }

        public virtual ICollection<CatCobertura> CatCoberturas { get; set; }
        public virtual ICollection<Poliza> Polizas { get; set; }
    }
}
