using System;
using System.Collections.Generic;

#nullable disable

namespace waSeguros.Models
{
    public partial class CatCobertura
    {
        public int CodRamo { get; set; }
        public int CodCobertura { get; set; }
        public string NombreCobertura { get; set; }
        public string Isuma { get; set; }

        public virtual CatRamo CodRamoNavigation { get; set; }
    }
}
