using System;
using System.Collections.Generic;

#nullable disable

namespace waSeguros.Models
{
    public partial class CatMunicipio
    {
        public CatMunicipio()
        {
            Clientes = new HashSet<Cliente>();
        }

        public int CodPais { get; set; }
        public int CodDepartamento { get; set; }
        public int CodMunicipio { get; set; }
        public string Xmunicipio { get; set; }
        public string Iestado { get; set; }

        public virtual CatDepartamento Cod { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
