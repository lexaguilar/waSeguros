using System;
using System.Collections.Generic;

#nullable disable

namespace waSeguros.Models
{
    public partial class CatMonedum
    {
        public CatMonedum()
        {
            Polizas = new HashSet<Poliza>();
        }

        public int CodMoneda { get; set; }
        public string Moneda { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Poliza> Polizas { get; set; }
    }
}
